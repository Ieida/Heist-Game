using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
  [SerializeField] AreaName _restrictedArea;
  List<GameObject> _suspects = new List<GameObject>();
  [SerializeField] Vision _vision;
  
  bool FindSuspiciousObjects()
  {
    foreach (var obj in _vision.VisibleObjects)
    {
      if (IsSuspicious(obj)) _suspects.Add(obj);
    }
  }
  
  bool IsSuspicious(GameObject go) => Area.GetAreaOf(go) == _restrictedArea);
  
  void Update()
  {
    FindSuspiciousObjects();
  }
}