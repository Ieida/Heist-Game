using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
  public struct AreaInfo
  {
    public AreaName Name {get;set;}
    public int NumberOfEntries {get;set;}
    
    public AreaInfo(AreaName name = null, int numberOfEntries = 0)
    {
      Name = name;
      NumberOfEntries = numberOfEntries;
    }
  }
  
  [SerializeField] AreaName _name; // Assign in the inspector
  static Dictionary<GameObject, AreaInfo> _objects = new Dictionary<GameObject, AreaInfo>();
  
  public static AreaName GetAreaOf(GameObject go)
  {
    AreaInfo arInf = default(AreaInfo);
    _objects.TryGetValue(go, out AreaInfo arInf);
    return arInf.NumberOfEntries > 0 ? arInf.Name : null;
  }
  
  void OnTriggerEnter(Collider col) => SetAreaOf(col.gameObject, _name, 1);
  
  void OnTriggerExit(Collider col) => SetAreaOf(col.gameObject, _name, -1);
  
  static void SetAreaOf(GameObject go, AreaName aname, int isEntry)
  {
    if (!_objects.ContainsKey(go)) _objects.Add(go, new AreaInfo(aname, 1));
    else
    {
      isEntry = Mathf.Clamp(isEntry, -1, 1);
      AreaInfo arInf = _objects[go];
      arInf.Name = aname;
      arInf.NumberOfEntries += isEntry;
      _objects[go] = arInf;
    }
  }
}
