using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour {
	
	Collider item;
	public Text text;
<<<<<<< HEAD
	public static GameObject OnObject;
	public bool inBox;
=======
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

				}
				else if (Input.GetKeyDown(KeyCode.E) && attached == true){
					playerPrefab.GetComponent<MeshRenderer>().enabled = true;
					transform.parent = null;
					attached = false;
					inBox = false;
					playerPrefab.GetComponent<PlayerVisibility>().isVisible = false;

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
	void OnTriggerEnter(Collider activator) {
		text.text = "Press [E] to use item.";
		allThingsInBox.Add(activator);
>>>>>>> parent of b522723... Revert "Merge pull request #14 from drfuzzyness/shaun"

	void OnTriggerEnter(Collider other) {
		text.text = "Press [E] to pick up item";
		//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
		//text.text = "Press [E] to pick up" + itemName;
		OnObject = other.gameObject;
	}
	
	void OnTriggerExit(Collider other) {
		if (OnObject == this.gameObject) OnObject = null;
	}

}
