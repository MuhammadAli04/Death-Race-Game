
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Death_Race_AIWaypointsContainer : MonoBehaviour {

	public Type type;
	public enum Type {FollowWaypoints, ChaseThisObject}

	public List<Transform> waypoints = new List<Transform>();
	public Transform target;

	// Used for drawing gizmos on Editor.
	void OnDrawGizmos() {
		
		for(int i = 0; i < waypoints.Count; i ++){
			
			Gizmos.color = new Color(4.0f, 6.0f, 8.0f, 0.9f);
			Gizmos.DrawCube(waypoints[i].transform.position, new Vector3(1, 1, 1));
			//Gizmos.DrawWireSphere (waypoints[i].transform.position, 20f);

			if (i < waypoints.Count - 1){
				
				if(waypoints[i] && waypoints[i+1]){
					
					if (waypoints.Count > 0) {
						
						Gizmos.color = Color.black;

						if(i < waypoints.Count - 1)
							Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position); 
						if(i < waypoints.Count - 2)
							Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position); 
						
					}

				}

			}

		}
		
	}
	
}
