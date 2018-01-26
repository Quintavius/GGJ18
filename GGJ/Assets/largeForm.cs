using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class largeForm : MonoBehaviour {
	public GameObject alternateForm;
	public camera cam;
	GameObject alt;
	float speed = 4;
	Animator anim;
	bool rightJump = false;
	bool leftJump = false;
	bool jump = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			transform.position += new Vector3 (0, 0,  Time.deltaTime * speed);
			anim.SetBool ("walking", true);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			anim.SetBool ("walking", false);
		}


		if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetBool ("back", true);
			transform.position += new Vector3 (0, 0,  Time.deltaTime * speed*-1.0f);
			transform.rotation = Quaternion.Euler (0, 180, 0);


		}
		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			anim.SetBool ("back", false);
		}

		//jump
		if (Input.GetKey (KeyCode.Space) && Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("jump", true);
			rightJump = true;
		}
		if (Input.GetKey (KeyCode.Space) && Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetBool ("jump", true);
			leftJump = true;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("jump", false);
			rightJump = false;
			leftJump = false;
		}
		if (rightJump)
			transform.position += new Vector3 (0, 0,  Time.deltaTime * speed);
		if (leftJump)
			transform.position += new Vector3 (0, 0,  Time.deltaTime * speed*-1.0f);

		if (Input.GetKeyDown (KeyCode.C))
		{
			Vector3 pos = transform.position;
			//Destroy(GetComponent<collider>());
			alt = Instantiate (alternateForm);
			//alt.transform.position = gameObject.transform.position;
			cam.player = alt;
			//Instantiate (alternateForm,gameObject.transform);
			//cam.player.transform.position = gameObject.transform.position;
			//Destroy (gameObject);
			transform.position += new Vector3 (0, 0,  10000);
			alt.transform.position = pos;
			Destroy (gameObject);
		}
	}
}
