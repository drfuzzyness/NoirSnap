using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour {

	private float counter = 0f;
	
	[Header("Setup")]
	private bool hasBeenInformed;
	public List<float> change_state;
	public List<GameObject> informStateChange;

	public void OnCollected(){
	
		counter += GetComponent<Evidence>().value;

	}
	// Update is called once per frame
	void Update () {
	
		for (int i = 0; i < change_state.Count; i++) {
			if (counter >= change_state[i] && hasBeenInformed == false){
				gameObject.SendMessage( "StateChanged" );
				informStateChange[i].SendMessage( "OnCollected" );
				hasBeenInformed = true;
			}
		}
	}
}

