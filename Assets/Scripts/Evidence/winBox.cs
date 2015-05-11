using UnityEngine;
using System.Collections;

public class winBox : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider activator ) {
	
		LevelManager.instance.playerWon();

	}
	void OnTriggerExit(Collider exiter) {
	
		//        if (OnObject == this.gameObject) OnObject = null;

	}
}
