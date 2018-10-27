using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {
	public float range;
	public float speed;

	float point;
	bool direction;
	// Use this for initialization
	void Start () {
		point = range / 2;
		// true is right, false is left
		direction = true;
	}

	// Update is called once per frame
	void Update () {
		if (point > range) {
			direction = false;
		}
		else if (point < 0) {
			direction = true;
		}

		if (direction == true) {
			transform.position += new Vector3(0f,(speed * 0.01f),0f);
			point += speed * 0.01f;
		}
		else if (direction == false) {
			transform.position -= new Vector3(0f,(speed * 0.01f),0f);
			point -= speed * 0.01f;
		}
	}
}
