using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
//This goes on every light to check for the player. 
public class LightManager : MonoBehaviour {
	//The light goes into the child of this object and gets aligned with the red debug circle. -90 x rotation should do it
	public Light childLight;
	[HideInInspector]
	public float radius;
	[HideInInspector]
	public float angle;
	public LayerMask playerMask;
	public LayerMask obstacleMask;
	LightState lightState;
	private void Start(){
		lightState = FindObjectOfType<LightState>();
	}
		void Update(){
		radius = childLight.range;
		angle = childLight.spotAngle;
		LookForPlayer();
	}
	//See if there's a player inside radius 
	void LookForPlayer(){
		Debug.Log("Looking for player");
		Collider[] playerInViewRadius = Physics.OverlapSphere(transform.position, radius, playerMask);

		if (playerInViewRadius.Length != 0){													//Is the player within range?
			Transform player = playerInViewRadius [0].transform;
			Vector3 dirToPlayer = (player.position - transform.position).normalized;

			if (Vector3.Angle (transform.up, dirToPlayer) < angle / 2){							//Is the player within view angle?
				float distToPlayer = Vector3.Distance(transform.position, player.position);

				if (!Physics.Raycast(transform.position, dirToPlayer, distToPlayer, obstacleMask)){			//Is the player occluded?
					//Light is shining on player
					lightState.playerIsLit = true;
					Debug.Log("Found Player");
				}else{
					lightState.playerIsLit = false;
					Debug.Log("Player occluded");
				}
			}else{
				lightState.playerIsLit = false;
				Debug.Log("No Player in angle");
			}
		}else{
				lightState.playerIsLit = false;
				Debug.Log("No Player in range");
			}
	}
	public Vector3 dirFromAngle(float angleInDegrees, bool angleIsGlobal){
		if (!angleIsGlobal){
			angleInDegrees -= transform.eulerAngles.z;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
	}
}
