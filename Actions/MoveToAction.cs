using UnityEngine;
using UnityEngine.AI;

public class MoveToAction : Action
{
  [field:SerializeField] public NavMeshAgent NavAgent{get;private set;}
  
  public override void Execute() {}
}