using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class pickupItem : MonoBehaviour {

	public Text text;
	public Transform playerPrefab;        // ASSIGN IN INSPECTOR Ayyyyy
	public bool inBox = false;
	public bool isMoving = false;
	bool attached = false;
	Vector3 curPos = new Vector3();
	public static pickupItem instance;



	public  List<Collider> allThingsInBox = new List<Collider> ();

	void Awake(){

		instance = this;

	}
	void Start(){
		text.text = "";
		curPos = playerPrefab.transform.position;
		playerPrefab = ParticipantManager.instance.player.transform;
	}


	void Update(){
		foreach (Collider thisThingInBox in allThingsInBox){
			Debug.Log (thisThingInBox);
			Debug.Log (allThingsInBox.Count);
			if (thisThingInBox.tag == "Player"){
				text.text = "Press [E] to use item.";


				if (Input.GetKeyDown(KeyCode.E) && attached == false){
					playerPrefab.GetComponent<MeshRenderer>().enabled = false;
					playerPrefab.transform.position = transform.position;
					transform.parent = playerPrefab.transform;
					attached = true;
					inBox = true;
					gameObject.AddComponent<PlayerGameInteractions>();
//					playerPrefab.GetComponent<CapsuleCollider>().radius = 1;


				}
				else if (Input.GetKeyDown(KeyCode.E) && attached == true){
					playerPrefab.GetComponent<MeshRenderer>().enabled = true;
					transform.parent = null;
					attached = false;
					inBox = false;
					playerPrefab.GetComponent<PlayerVisibility>().isVisible = false;
					Destroy(GetComponent<PlayerGameInteractions>());
					allThingsInBox.Remove(playerPrefab.GetComponent<Collider>());   // Getting rid of this piece of code turns the box into a Teleporter.
				}
			}
		}

		if (inBox == true){
			if (curPos != playerPrefab.transform.position){
				playerPrefab.GetComponent<PlayerVisibility>().isVisible = true;
				isMoving = true;
				curPos = playerPrefab.transform.position;
			}
			// if the current position and the new position are the same, then the player is not visible to enemies
			else if (curPos == playerPrefab.transform.position){
				playerPrefab.GetComponent<PlayerVisibility>().isVisible = false;
				isMoving = false;
				
			}
			
		}
	}
	void OnTriggerEnter(Collider activator) {
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
