using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjectSoundManager : MonoBehaviour {
	public AudioClip[] impactSounds;
	AudioSource source;
	Rigidbody rb;

	private void Start(){
		source = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision col){
		var volumeMod = Mathf.Clamp01(rb.velocity.magnitude / 5);
		source.volume = volumeMod;
		int soundArraySize = impactSounds.Length;
		AudioClip chosenImpactSound = impactSounds[Random.Range(0,soundArraySize)];
		source.PlayOneShot(chosenImpactSound);
	}
}
