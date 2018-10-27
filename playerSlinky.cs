using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlinky : MonoBehaviour {
	// The Rigidbody component attached to this gameObjectd
	Rigidbody rb;

	// Input axis values
	float horizontalInput;
	float verticalInput;

	public float speed;

	float stretch;

	float Xstretch;
	float Zstretch;

	float Xpos;
	float Zpos;
	// Use this for initialization
	void Start () {
		// Set rb to Rigidbody component attached to this gameObject
		rb = GetComponent<Rigidbody> ();

		transform.localScale = new Vector3(1, 1, 1);
		//transform.position = new Vector3(0,0,0);

		stretch = 0;
		Xstretch = 1;
		Zstretch = 1;
		Xpos = 0;
		Zpos = 0;
	}

	// Update is called once per frame
	void Update () {

		// Get movement inputs
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");

			if (Input.GetKeyDown (KeyCode.Space) && verticalInput < 0f && Xstretch == 1 && Zstretch == 1) {
				stretch = 3;
				Debug.Log(stretch);
			}
			else if (Input.GetKeyDown (KeyCode.Space) && verticalInput > 0f && Xstretch == 1 && Zstretch == 1) {
				stretch = 4;
				Debug.Log(stretch);

			}
			else if (Input.GetKeyDown (KeyCode.Space) && horizontalInput < 0f && Xstretch == 1 && Zstretch == 1) {
				stretch = 1;
				Debug.Log(stretch);
			}
			else if (Input.GetKeyDown (KeyCode.Space) && horizontalInput > 0f && Xstretch == 1 && Zstretch == 1) {
				stretch = 2;
				Debug.Log(stretch);

			}
			else if (Input.GetKeyDown (KeyCode.Space)) {
				stretch = 0;
				Debug.Log(stretch);

			}

			if (stretch == 0) {
				if (Xstretch != 1) {
					transform.localScale -= new Vector3(speed / 100f, 0f, 0f);
					Xstretch -= speed / 10;
					//Debug.Log(Xstretch);
					if (Xpos > 0) {
						transform.position -= new Vector3(speed / 200f, 0f, 0f);
						Xpos -= speed / 10;
						//Debug.Log(Xpos);
					}
					else if (Xpos < 0) {
						transform.position += new Vector3(speed / 200f, 0f, 0f);
						Xpos += speed / 10;
						//Debug.Log(Xpos);
					}
				}
				else if (Zstretch != 1) {
					transform.localScale -= new Vector3(0f, 0f, speed / 100f);
					Zstretch -= speed / 10;
					if (Zpos > 0) {
						transform.position -= new Vector3(0f, 0f, speed / 200f);
						Zpos -= speed / 10;
						//Debug.Log(Zpos);
					}
					else if (Zpos < 0) {
						transform.position += new Vector3(0f, 0f, speed / 200f);
						Zpos += speed / 10;
						//Debug.Log(Zpos);

					}
				}

			}
			else if (Xstretch < 100f && Zstretch < 100f) {
			  if (stretch == 1) {
				transform.localScale += new Vector3(speed / 100f, 0f, 0f);
				Xstretch += speed / 10;
				//Debug.Log(Xstretch);

				transform.position -= new Vector3(speed / 200f, 0f, 0f);
				Xpos += speed / 10;
				//Debug.Log(Xpos);
			}
			else if (stretch == 2) {
				transform.localScale += new Vector3(speed / 100f, 0f, 0f);
				Xstretch += speed / 10;
				//Debug.Log(Xstretch);

				transform.position += new Vector3(speed / 200f, 0f, 0f);
				Xpos -= speed / 10;
				//Debug.Log(Xpos);
			}
			else if (stretch == 3) {
				transform.localScale += new Vector3(0f, 0f, speed / 100f);
				Zstretch += speed / 10;
				///Debug.Log(Zstretch);

				transform.position -= new Vector3(0f, 0f, speed / 200f);
				Zpos += speed / 10;
			//	Debug.Log(Zpos);


			}
			else if (stretch == 4) {
				transform.localScale += new Vector3(0f, 0f, speed / 100f);
				Zstretch += speed / 10;
				//Debug.Log(Zstretch);

				transform.position += new Vector3(0f, 0f, speed / 200f);
				Zpos -= speed / 10;
				//Debug.Log(Zpos);
			}
	}
	}
}
