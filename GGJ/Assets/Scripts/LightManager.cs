﻿using System.Collections;
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
	public float meshResolution;
	public MeshFilter haloMeshFilter;
	Mesh haloMesh;
	private void Start(){
		lightState = FindObjectOfType<LightState>();

		haloMesh = new Mesh();
		haloMesh.name = "Halo Mesh";
		haloMeshFilter.mesh = haloMesh;
	}
	private void Update(){
		radius = childLight.range;
		angle = childLight.spotAngle;
		LookForPlayer();
	}

	private void LateUpdate(){
		DrawHalo();
	}

	void DrawHalo(){
		int stepCount = Mathf.RoundToInt(angle * meshResolution);
		float stepAngleSize = angle / stepCount;

		List<Vector3> viewPoints = new List<Vector3>();

		for (int i = 0; i <= stepCount; i++){
			float meshAngle = transform.eulerAngles.z - angle/2 + stepAngleSize * i -4;
			ViewCastInfo newViewCast = ViewCast(meshAngle);
			viewPoints.Add(newViewCast.point);
		}

		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount-2)*3];

		vertices[0] = Vector3.zero;
		for (int i = 0; i < vertexCount-1; i++){
			vertices[i+1] = transform.InverseTransformPoint(viewPoints[i]);

			if (i < vertexCount -2){
				triangles[i*3] = 0;
				triangles[i*3+1] = i+1;
				triangles[i*3+2] = i+2;
			}
		}
		haloMesh.Clear();
		haloMesh.vertices = vertices;
		haloMesh.triangles = triangles;
		haloMesh.RecalculateNormals();
	}

	ViewCastInfo ViewCast(float globalAngle){
		Vector3 dir = dirFromAngle(globalAngle, true);
		RaycastHit hit;
		if (Physics.Raycast(transform.position, dir, out hit, radius, obstacleMask)){
			return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
		}else{
			return new ViewCastInfo(false, transform.position + dir * radius, radius, globalAngle);
		}
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

	public struct ViewCastInfo{
		public bool hit;
		public Vector3 point;
		public float dist;
		public float angle;

		public ViewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle){
			hit = _hit;
			point = _point;
			dist = _dist;
			angle = _angle;
		}
	}
}
