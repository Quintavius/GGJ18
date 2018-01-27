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

	//References
	Animator ani;
	player2 movement;

	private void Start(){
		movement = FindObjectOfType<player2>();
		ani = GetComponentInChildren<Animator>();
	}
	
	private void Update(){
		
	}

}
