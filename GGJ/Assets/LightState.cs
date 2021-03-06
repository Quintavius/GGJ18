﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds whether the player is lit by anything
public class LightState : MonoBehaviour {
	public bool playerIsLit;
	public Animator ani;
	[HideInInspector]
	public int activeLights;

	private void Update(){
		ani.SetBool("isLit", playerIsLit);
	}
}
