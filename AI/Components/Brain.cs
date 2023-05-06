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
  
  [SerializeField] Decision[] _decisions;
  float _evaluationDeltaTime;
  [SerializeField, Tooltip("Per second.")] float _evaluationRate;
  
  void Act(Decision decision) => decision.Action.Act();
  
  Decision Evaluate()
  {
    Decision chsn = null;
    for (int i = 0; i < _decisions.Length; i++)
    {
      var dec = _decisions[i];
      dec.Evaluate();
      if (dec.Score > chsn.Score) chsn = dec;
    }
    return chsn;
  }
  
  void Update()
  {
    _evaluationDeltaTime += Time.deltaTime;
    if (_evaluationDeltaTime >= _evaluationRate / 1000f)
    {
      _evaluationDeltaTime = 0f;
      var dec = Evaluate();
      Act(dec);
    }
  }
}