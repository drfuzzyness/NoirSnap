using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour {
	
	Collider item;
	Collider playerInside;


	public Text text;


	public static GameObject OnObject;
	public Transform playerPrefab;


	public bool inBox = false;
	bool attached = false;

	void Start(){
		text.text = "";
	}


	void Update(){

		if (playerInside != null){

			//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
			//text.text = "Press [E] to pick up" + itemName;

			if (Input.GetKeyDown(KeyCode.E) && attached == false){

				//Code where item is added to list player can access
				transform.parent = playerPrefab.transform;
				playerInside.GetComponent<StealthPercent>().isVisible = false;
				attached = true;
				text.text = "Press [E] to drop item";
				inBox = true;
			}
			else if (Input.GetKeyDown(KeyCode.E) && attached == true){
				transform.parent = null;
				playerInside.GetComponent<StealthPercent>().isVisible = true;
				attached = false;
				text.text = "Press [E] to pick up item";
				inBox = false;
			}

		}


	}
	void OnTriggerEnter(Collider other) {


		if(other.tag == "Player")
		{
			text.text = "Press [E] to pick up item";
			OnObject = other.gameObject;
		}//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
		//text.text = "Press [E] to pick up" + itemName

		playerInside = other;


		OnObject = other.gameObject;
	

	}
	
	void OnTriggerExit(Collider exiter) {
		text.text = "";
		playerInside = null;


		if (OnObject == this.gameObject) OnObject = null;

	}

}
