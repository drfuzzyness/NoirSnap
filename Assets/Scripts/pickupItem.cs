using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickupItem : MonoBehaviour {
	
	Collider item;
	public Text text;
	public static GameObject OnObject;
	public bool inBox;

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
