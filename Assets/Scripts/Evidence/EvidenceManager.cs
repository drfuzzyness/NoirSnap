using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour {

	
	public float counter = 0f;
//	[Header("Setup")]
//	private bool hasBeenInformed;
	public float change_state;
//	public List<GameObject> informStateChange;
//
	void Start (){


	}

	void Update(){


	}

	public void OnCollected(){
	
		counter += GetComponent<Evidence>().value;
		Debug.Log( "Evidence Manager now has " + counter + " points.");

	}


	


//	// Update is called once per frame
//	void Update () {
//	
//		for (int i = 0; i < change_state; i++) {
//			if (counter >= change_state[i] && hasBeenInformed == false){
//				gameObject.SendMessage( "StateChanged" );
//				informStateChange[i].SendMessage( "StateChanged" );
//				hasBeenInformed = true;
//			}
//			if (counter >= change_state[i]) {
//				LevelManager.instance.playerWon();
//			}
//		}
//	}
}

