﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
	public Quaternion NewRotation;
	Rigidbody m_rigidBody;
	public float jump;
	public float speed;
	bool big = false;
	float distToGround = 0.0f;
	// Use this for initialization
	void Start () {
		m_rigidBody = GetComponent<Rigidbody> ();
		NewRotation = transform.rotation;
		//gameObject.GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !big) 
		{
			if (IsGrounded ()) 
			{
				m_rigidBody.velocity += new Vector3 (0.0f, jump, 0.0f);
			}
		}	


		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			m_rigidBody.velocity += new Vector3 (speed*Time.deltaTime, 0.0f, 0.0f);
		}	

		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			m_rigidBody.velocity += new Vector3 (-1.0f * speed * Time.deltaTime, 0.0f,  0.0f);
		}	

		//if (big) {
		//	gameObject.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
		//} else {
		//	gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		//}

		if (Input.GetKeyDown(KeyCode.C)) 
		{
			big = !big;
		}	
		m_rigidBody.velocity = new Vector3(m_rigidBody.velocity.x ,m_rigidBody.velocity.y,0);
		//gameObject.transform.rotation = Quaternion.Euler (0, 90, 0);


	}
	void FixedUpdate()
	{
		transform.rotation = NewRotation;
	}

	bool IsGrounded()
	{
		distToGround = 0.5f;
		return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
	}
}