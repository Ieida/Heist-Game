using UnityEngine;

public class RestrictedArea : MonoBehaviour
{
  void OnTriggerEnter(Collider col) => col.AddComponent(typeof(SuspectTag));
  
  void OnTriggerExit(Collider col) => Destroy(col.GetComponent<SuspectTag>());
}