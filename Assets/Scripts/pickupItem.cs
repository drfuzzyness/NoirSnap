using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour {
	
	Collider item;
	public Text text;
	public static GameObject OnObject;

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Player")
		{
			text.text = "Press [E] to pick up item";
			OnObject = other.gameObject;
		}//FIND OUT HOW TO CHANGE ITEM NAME BASED ON ACTUAL ITEM STRING
		//text.text = "Press [E] to pick up" + itemName
	}
	
	void OnTriggerExit(Collider other) {
		if (OnObject == this.gameObject) OnObject = null;
	}

}
