using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderControls : MonoBehaviour {
	CharacterController character;
	public Rigidbody pushCube;
	public float speed = 5;
	public float jump = 6;
	public float gravity = 9;
	LightState lit;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
		lit = GetComponent<LightState>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);

		character.SimpleMove(new Vector3 (0,-gravity,0));

		if (character.isGrounded){
			Vector3 move = new Vector3(Input.GetAxis("Horizontal") * speed, 0,0);
			character.SimpleMove(move);
			float litState = 1 - System.Convert.ToSingle(lit.playerIsLit);
			character.Move(new Vector3(0, litState * System.Convert.ToSingle(Input.GetButtonDown("Jump")) * jump * Time.deltaTime, 0));
		}	
	}

	private void OnCollisionStay(Collision other){
		if (other.gameObject.tag == "Moveable"){
			if (!lit.playerIsLit){
				other.gameObject.GetComponent<Rigidbody>().constraints =
					RigidbodyConstraints.FreezePositionZ |
					RigidbodyConstraints.FreezeRotationX |
					RigidbodyConstraints.FreezeRotationY ;
			}else{
				other.gameObject.GetComponent<Rigidbody>().constraints =
					RigidbodyConstraints.FreezePositionX |
					RigidbodyConstraints.FreezePositionY |
					RigidbodyConstraints.FreezePositionZ |
					RigidbodyConstraints.FreezeRotationX |
					RigidbodyConstraints.FreezeRotationY |
					RigidbodyConstraints.FreezeRotationZ ;
			}
		}
	}
}
