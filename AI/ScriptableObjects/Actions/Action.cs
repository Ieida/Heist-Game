using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Actions/Action", order = 0)]
public class Action : ScriptableObject
{
  public abstract void Act();
}