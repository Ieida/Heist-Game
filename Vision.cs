using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
	[SerializeField, Range(0f, 360f), Tooltip("Vision angle.")] float _angle;
	[SerializeField, Tooltip("Vision point.")] Transform _eyes;
	[SerializeField, Tooltip("Layers which block the vision.")] LayerMask _obstacleLayers;
	Collider[] _overlaps = new Collider[32];
	int _overlapsLength;
	[SerializeField] float _radius;
	[SerializeField, Tooltip("Layers which can be seen.")] LayerMask _targetLayers;
	List<GameObject> _visibleObjects = new List<GameObject>(32);
	public GameObject[] VisibleObjects => _visibleObjects.ToArray();
	
	void FindVisibleObjects()
	{
    _visibleObjects.Clear();

		// Filter by visibility
		for (int i = 0; i < inRngCnt; i++)
		{
		  Transform ovlp = _overlaps[i];
		  if (IsVisible(ovlp.position) _visibleObjects.Add(ovlp.gameObject);
		}
	}
	
	void FixedUpdate()
	{
	  GetObjectsInRange();
	}
	
	void GetObjectsInRange()
	{
	  _overlapsLength = Physics.OverlapSphereNonAlloc(_eyes.position, _radius, _overlaps, _targetLayers);
	}
	
	bool IsVisible(Vector3 point)
	{
		Vector3 dir = (point - _eyes.position).normalized;
		float ang = Vector3.Angle(_eyes.forward, dir);
		return ang <= _angle * 0.5f &&
		!Physics.LineCast(
			_eyes.position,
			point,
			_obstacleLayers);
	}

	void OnDrawGizmosSelected()
	{
		// Draw radius
		Color clr = Color.green;
		clr.a = 0.2f;
		Gizmos.Color = clr;
    Gizmos.DrawSphere(_eyes.position, _radius);

		//Draw angle
		Gizmos.Color = Color.blue;
		Quaternion rot = Quaternion.Euler(0f, _angle, 0f);
		Vector3 dir = _eyes.rotation * rot * Vector3.forward;
		Gizmos.DrawRay(_eyes.position, dir * _radius);
		dir = _eyes.rotation * Quaternion.Inverse(rot) * Vector3.forward;
		Gizmos.DrawRay(_eyes.position, dir * _radius);

		// Draw visible targets
		Gizmos.color = Color.green
		for (int i = 0; i < VisibleObjects.Count; i++)
		{
			Gizmos.DrawLine(_eyes.position, _visibleObjects[i].transform.position, pos);
		}
	}
	
	void Update()
	{
	  FindVisibleObjects();
	}
}