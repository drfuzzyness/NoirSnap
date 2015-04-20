using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

	public float speed = 5f;
	public float turnSpeed = 5f;
<<<<<<< HEAD
	public Transform itemBox;
	public Text text;
	// public bool isSneaking = false;
=======
>>>>>>> fc2b5e5cdef40f005d1ad5a8d129e829ae6433bd



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

<<<<<<< HEAD
		if (Input.GetKey(KeyCode.LeftShift)){

			rbody.AddForce (transform.forward * sneakSpeed * Input.GetAxis("Vertical"));


		}

		if (Input.GetKeyDown(KeyCode.E)){
			if (pickupItem.OnObject){
				Destroy (itemBox);
				text.text = "You have the item!";
			}
		}
=======

>>>>>>> fc2b5e5cdef40f005d1ad5a8d129e829ae6433bd

	}

}

