using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Necessary for changing scenes
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	public int coinRequirement;

	// Helper bool
	bool loadNextLevel;

	// Next level name
	public string nextLevel;

	// Exit sound effect, kept as a variable to reduce GetComponent() calls
	AudioSource aSource;

	// Use this for initialization
	void Start () {

		// Set exit sound effect to AudioSource component attached to this gameObject
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		// If the helper bool is true and the sound has stopped, load the next level
		if (loadNextLevel && !aSource.isPlaying) {
			SceneManager.LoadScene(nextLevel);
		}
	}

	// OnTriggerEnter is called when a collider enters the trigger collider attached to this object
	void OnTriggerEnter(Collider other){

		// Is the other object a player?
		if (other.gameObject.CompareTag ("Player")) {

			// Does the player have enough coins?
			if (other.gameObject.GetComponent<Player>().coinCounter >= coinRequirement) {

				// Play exit sound
				aSource.Play();

				// Disable vital player components
				// Note: Why is destroying the player outright a poor solution here?
				other.gameObject.GetComponent<Player>().enabled = false;
				other.gameObject.GetComponent<MeshRenderer>().enabled = false;
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

				loadNextLevel = true;
			}
		}
	}
}
