using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour {

	private float counter = 0f;
	
	[Header("Setup")]
	public float change_state;
	public List<GameObject> informStateChange;

	public void OnCollected(){
	
		counter += GetComponent<Evidence>().value;

	}
	// Update is called once per frame
	void Update () {
	
		if (counter >= change_state){
			gameObject.SendMessage( "StateChanged" );
			foreach( GameObject thisObj in informStateChange ) {
				thisObj.SendMessage( "StateChanged" );
			}
		}

	}
}
