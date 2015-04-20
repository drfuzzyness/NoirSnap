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
<<<<<<< HEAD

		if(other.tag == "Player")
		{
			text.text = "Press [E] to pick up item";
			OnObject = other.gameObject;
		}//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
		//text.text = "Press [E] to pick up" + itemName
=======
		playerInside = other;


		OnObject = other.gameObject;
	

>>>>>>> fc2b5e5cdef40f005d1ad5a8d129e829ae6433bd
	}
	
	void OnTriggerExit(Collider exiter) {
		text.text = "";
		playerInside = null;


		if (OnObject == this.gameObject) OnObject = null;

	}

}
