using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour {
	
	Collider item;
	Collider playerInside;
	public Text text;
	public static GameObject OnObject;

	void Start(){
		text.text = "";
	}


	void Update(){

		if (playerInside != null){

			text.text = "Press [E] to pick up item";
			//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
			//text.text = "Press [E] to pick up" + itemName;

			if (Input.GetKeyDown(KeyCode.E)){

				//Code where item is added to list player can access

			}

		}


	}
	void OnTriggerEnter(Collider other) {
		playerInside = other;


		OnObject = other.gameObject;
	

	}
	
	void OnTriggerExit(Collider exiter) {
		text.text = "";
		playerInside = null;


		if (OnObject == this.gameObject) OnObject = null;

	}

}
