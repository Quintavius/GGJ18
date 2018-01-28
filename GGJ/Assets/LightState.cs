using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds whether the player is lit by anything
public class LightState : MonoBehaviour {
	public bool playerIsLit;
	public Animator ani;
	public int activeLights = 0;

	private void Awake(){
		activeLights = 0;
	}
	private void Update(){
		ani.SetBool("isLit", playerIsLit);
	}
}
