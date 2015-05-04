using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class pickupItem : MonoBehaviour {

	public Text text;
	public Transform playerPrefab;        // ASSIGN IN INSPECTOR Ayyyyy
	public bool inBox = false;
	bool attached = false;
	Vector3 curPos = new Vector3();


	public  List<Collider> allThingsInBox = new List<Collider> ();


	void Start(){
		text.text = "";
		curPos = playerPrefab.transform.position;
	}


	void Update(){

		foreach (var thisThingInBox in allThingsInBox){

			if (thisThingInBox.tag == "Player"){

				if (Input.GetKeyDown(KeyCode.E) && attached == false){
					playerPrefab.GetComponent<MeshRenderer>().enabled = false;
					playerPrefab.transform.position = transform.position;
					transform.parent = playerPrefab.transform;
					attached = true;
					inBox = true;

			if (Input.GetKeyDown(KeyCode.E) && attached == false){
				//Code where item is added to list player can access
				playerPrefab.GetComponent<MeshRenderer>().enabled = false;
				transform.parent = playerPrefab.transform;
				attached = true;
				text.text = "Press [E] to drop item";
				inBox = true;
				Debug.Log ("picked up");
			}
			else if (Input.GetKeyDown(KeyCode.E) && attached == true){
				playerPrefab.GetComponent<MeshRenderer>().enabled = true;
				transform.parent = null;
				attached = false;
				text.text = "Press [E] to pick up item";
				inBox = false;
				Debug.Log ("dropped");

				}
			}
		}

		if (inBox == true){
			if (curPos != playerPrefab.transform.position){
				playerPrefab.GetComponent<PlayerVisibility>().isVisible = true;
				curPos = playerPrefab.transform.position;
			}
			// if the current position and the new position are the same, then the player is not visible to enemies
			else if (curPos == playerPrefab.transform.position){
				playerPrefab.GetComponent<PlayerVisibility>().isVisible = false;
				
			}
			
		}
	}
}
	void OnTriggerEnter(Collider activator) {
		text.text = "Press [E] to use item.";
		allThingsInBox.Add(activator);

		//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
//		//text.text = "Press [E] to pick up" + itemName
//		OnObject = other.gameObject;
	}
	
	void OnTriggerExit(Collider exiter) {
		text.text = "";
		allThingsInBox.Remove(exiter);


//		if (OnObject == this.gameObject) OnObject = null;

	}

}
