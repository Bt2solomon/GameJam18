using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGravity : MonoBehaviour {

	Rigidbody rb;


	float horizontalInput;
	float verticalInput;

	float grav;

	public float speed;




	// Use this for initialization
	void Start () {
		// Set rb to Rigidbody component attached to this gameObject
		rb = GetComponent<Rigidbody> ();
		grav = 0;

	}

	// Update is called once per frame
	void Update () {
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");



		if (Input.GetKeyDown (KeyCode.Space) && verticalInput > 0f) {
			grav = 1;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && verticalInput < 0f) {
			grav = 2;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && horizontalInput < 0f) {
			grav = 3;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && horizontalInput > 0f) {
			grav = 4;
		}
		else if (Input.GetKeyDown (KeyCode.Space)) {
			grav = 0;
		}

		if (grav == 0) {
			Physics.gravity = new Vector3(0f,-100f,0f);
			rb.velocity =  (new Vector3 (horizontalInput * speed, rb.velocity.y, verticalInput * speed));
		}

		else if (grav == 1) {
			Physics.gravity = new Vector3(0f,0f,100f);
			rb.velocity =  (new Vector3 (horizontalInput * speed, verticalInput * speed, rb.velocity.z));
		}
		else if (grav == 2) {
			Physics.gravity = new Vector3(0f,0f,-100f);
			rb.velocity =  (new Vector3 (horizontalInput * speed, verticalInput * speed, rb.velocity.z));
		}
		else if (grav == 3) {
			Physics.gravity = new Vector3(-100f,0f,0f);
			rb.velocity =  (new Vector3 (rb.velocity.x, verticalInput * speed, horizontalInput * speed));
		}
		else if (grav == 4) {
			Physics.gravity = new Vector3(100f,0f,0f);
			rb.velocity =  (new Vector3 (rb.velocity.x, verticalInput * speed, horizontalInput * speed));

		}

	}
}
