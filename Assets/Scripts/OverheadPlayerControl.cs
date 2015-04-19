using UnityEngine;
using System.Collections;

public class OverheadPlayerControl : MonoBehaviour {

	public bool useControlScheme = true;
	public float speed = 5f;
	public float sneakSpeed = 5f;
	public float turnSpeed = 5f;
	// public bool isSneaking = false;

	

	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		// "caching" a reference to the rigidbody
		rbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rbody.AddForce (transform.forward * speed * Input.GetAxis("Vertical"));
		transform.Rotate (0f, Input.GetAxis ("Horizontal") * turnSpeed, 0f);

		if (Input.GetKey(KeyCode.LeftShift)){

			rbody.AddForce (transform.forward * sneakSpeed * Input.GetAxis("Vertical"));


		}



	}

}

