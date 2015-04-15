using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {
	//might not need this
	public Transform player;

	public float playerSpeed;
	public float turnSpeed;
	
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			GetComponent<Rigidbody>().AddForce(transform.forward * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
		}
		if(Input.GetKey(KeyCode.S)){
			GetComponent<Rigidbody>().AddForce(transform.forward * -playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(0f,-90f * turnSpeed * Time.deltaTime,0f);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(0f,90f * turnSpeed * Time.deltaTime,0f);
		}
	
	}
}
