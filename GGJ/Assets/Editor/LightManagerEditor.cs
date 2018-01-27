using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(LightManager))]
public class LightManagerEditor : Editor {
	void OnSceneGUI(){
		LightManager lightManager = (LightManager)target;
		Handles.color = Color.red;
		Handles.DrawWireArc(lightManager.transform.position, Vector3.forward, Vector3.up, 360, lightManager.radius);
		Vector3 angleA = lightManager.dirFromAngle(-lightManager.angle/2, false);
		Vector3 angleB = lightManager.dirFromAngle(lightManager.angle/2, false);

		Handles.DrawLine(lightManager.transform.position, lightManager.transform.position + (angleA * lightManager.radius));
		Handles.DrawLine(lightManager.transform.position, lightManager.transform.position + (angleB * lightManager.radius));
	}
}
