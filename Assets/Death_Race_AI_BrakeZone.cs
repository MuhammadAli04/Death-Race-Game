using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Race_AI_BrakeZone : MonoBehaviour
{
	public List<Transform> brakeZones = new List<Transform>();

	void OnDrawGizmos()
	{

		for (int i = 0; i < brakeZones.Count; i++)
		{

			Gizmos.matrix = brakeZones[i].transform.localToWorldMatrix;
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
			Vector3 colliderBounds = brakeZones[i].GetComponent<BoxCollider>().size;

			Gizmos.DrawCube(Vector3.zero, colliderBounds);

		}

	}
}
