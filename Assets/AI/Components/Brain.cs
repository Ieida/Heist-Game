using UnityEngine;

public class Brain : MonoBehaviour
{
  [System.Serializable]
  public struct Decision
  {
    [field:SerializeField] public Action Action{get;set;}
    [field:SerializeField] public Condition[] Conditions{get;set;}
    public int Score{get;private set;}
    
    public void Evaluate()
    {
      Score = 0;
      foreach (var con in Conditions)
      {
        Score += con.Evaluate();
      }
    }
  }
  
  Decision _decision;
  [SerializeField] Decision[] _decisions;
  float _evaluationDeltaTime;
  [SerializeField, Tooltip("Per second.")] float _evaluationRate;
  
  void Evaluate()
  {
    var chsn = default(Decision);
    for (int i = 0; i < _decisions.Length; i++)
    {
      var dec = _decisions[i];
      dec.Evaluate();
      
      if (dec.Score > chsn.Score) chsn = dec;
    }
    
    _decision = chsn;
  }
  
  void OnEnable()
  {
    _evaluationDeltaTime = _evaluationRate / 1000f;
  }
  
  void Update()
  {
    _evaluationDeltaTime += Time.deltaTime;
    if (_evaluationDeltaTime >= _evaluationRate / 1000f)
    {
      _evaluationDeltaTime = 0f;
      
      Evaluate();
    }
    
      if (_decision.Score > 0) _decision.Update();
  }
}