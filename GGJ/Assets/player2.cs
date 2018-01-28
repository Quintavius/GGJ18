using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
	bool moving = false;
	bool right = false;
	public Quaternion NewRotation;
	Rigidbody m_rigidBody;
	public float jump;
	public float speed;
	bool big = false;
	float distToGround = 0.0f;
	Animator anim;
	public GameObject child;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
		anim = child.GetComponent<Animator> ();
		m_rigidBody = GetComponent<Rigidbody> ();
		NewRotation = transform.rotation;
		//gameObject.GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		moving = false;
		if (Input.GetKeyDown (KeyCode.Space) && !(gameObject.GetComponent<LightState>().playerIsLit)) 
		{
			if (IsGrounded ()) 
			{
				m_rigidBody.velocity = new Vector3 (0.0f, jump, 0.0f);
			}
		}	


		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			right = true;
			moving = true;
			if (m_rigidBody.velocity.x < maxSpeed)
			m_rigidBody.velocity += new Vector3 (speed*Time.deltaTime, 0.0f, 0.0f);
		}	

		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			right = false;
			moving = true;
			if (m_rigidBody.velocity.x > (maxSpeed * -1.0f)) {
				m_rigidBody.velocity += new Vector3 (-1.0f * speed * Time.deltaTime, 0.0f, 0.0f);
			}
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



	}
	void FixedUpdate()
	{
		transform.rotation = NewRotation;
		transform.position = new Vector3 (transform.position.x, transform.position.y, -5.6f);
		anim.SetFloat("yvelocity", m_rigidBody.velocity.y);
		if (right) 
		{
			transform.Rotate (Vector3.up * 180);
		}
	}

	bool IsGrounded()
	{
		distToGround = 0.5f;
		return Physics.Raycast (transform.position, -Vector3.up, distToGround + 0.1f);
	}
}
