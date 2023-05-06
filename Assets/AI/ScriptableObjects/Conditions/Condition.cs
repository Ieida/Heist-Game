using UnityEngine;

[CreateAssetMenu(fileName = "New Condition", menuName = "Conditions/Condition", order = 0)]
public class Condition : ScriptableObject
{
  public abstract int Evaluate();
}