using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

public class pickupItem : MonoBehaviour {

	public Text text;
//	public static GameObject OnObject;
	public Transform playerPrefab;        // ASSIGN IN INSPECTOR Ayyyyy
	public bool inBox = false;
	bool attached = false;


	public  List<Collider> allThingsInBox = new List<Collider> ();


	void Start(){
		text.text = "";

	}


	void Update(){


		foreach (var thisThingInBox in allThingsInBox){
//		if (playerInside != null){			//text.text = "Press [E] to pick up" + itemName;

			if (thisThingInBox.tag == "Player"){


			if (Input.GetKeyDown(KeyCode.E) && attached == false){

				//Code where item is added to list player can access
				playerPrefab.GetComponent<MeshRenderer>().enabled = false;
				transform.parent = playerPrefab.transform;
				attached = true;
				text.text = "Press [E] to drop item";
				inBox = true;
				
			}
			else if (Input.GetKeyDown(KeyCode.E) && attached == true){
				playerPrefab.GetComponent<MeshRenderer>().enabled = true;
				transform.parent = null;
				attached = false;
				text.text = "Press [E] to pick up item";
				inBox = false;
				}
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
