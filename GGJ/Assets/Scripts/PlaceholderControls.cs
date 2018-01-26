using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderControls : MonoBehaviour {
	CharacterController character;
	public float speed = 5;
	public float jump = 6;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		character.SimpleMove(new Vector3 (0,-3,0));

		if (character.isGrounded){
			Vector3 move = new Vector3(Input.GetAxis("Horizontal") * 5,Input.GetAxis("Vertical") * jump,0);
			character.SimpleMove(move);
		}
	}
}
