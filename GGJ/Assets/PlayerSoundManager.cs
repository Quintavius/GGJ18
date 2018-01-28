using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {
	[Header("SourceSounds")]
	public AudioClip[] bubblesSteps;
	public AudioClip[] puddlesSteps;
	public AudioClip[] jumpSounds;
	public AudioClip[] dropSounds;
	public AudioClip[] pushSounds;

	AudioSource source;

	//References
	Animator ani;
	player2 movement;

	private void Start(){
		movement = FindObjectOfType<player2>();
		ani = GetComponentInChildren<Animator>();
		source = GetComponent<AudioSource>();
	}
	
	private void Update(){
		if (Input.GetButtonDown("Jump") && movement.IsGrounded()){
			int soundArraySize = jumpSounds.Length;
			AudioClip chosenImpactSound = jumpSounds[Random.Range(0,soundArraySize)];
			source.PlayOneShot(chosenImpactSound);
		}
	}

}
