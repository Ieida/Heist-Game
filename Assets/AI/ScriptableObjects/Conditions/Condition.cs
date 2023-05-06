using UnityEngine;

[CreateAssetMenu(fileName = "New Condition", menuName = "Conditions/Condition", order = 0)]
public class Condition : ScriptableObject
{
  [field:SerializeField] int Points{get;set;}
  
  public abstract bool Evaluate();
}