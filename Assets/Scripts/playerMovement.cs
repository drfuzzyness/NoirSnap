using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {

	public float speed = 5f;
	bool hasItem = false;
	public Text text;
	public GameObject itemBox;

	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= transform.right * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.E)){
			if (pickupItem.OnObject){
				this.hasItem = true;
				Destroy(itemBox);
				text.text = "You have the item!";
			}
		}
	}
}
