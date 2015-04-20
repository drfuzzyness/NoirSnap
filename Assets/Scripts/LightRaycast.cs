using UnityEngine;
using System.Collections;

public class LightRaycast : MonoBehaviour {

	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// ray from spotlight to the ground
		Ray lightRay = new Ray(transform.position, transform.forward);
		// gets a list of all the colliders the light ray is hitting
		RaycastHit[] obstacles = Physics.SphereCastAll (lightRay, 2.3f,50f);
		// goes through the list of colliders
		for (int i = 0; i < obstacles.Length; i++){
			// checks if one of the colliders hit is the Player
			if (obstacles[i].collider.tag == "Player"){
				// if one of them is the player set the stealth status to false
				playerPrefab.GetComponent<StealthPercent>().stealth = false;
				break;

			}
			else{
				
				playerPrefab.GetComponent<StealthPercent>().stealth = true;
				
			}

		}
		// previous code used. not good. ignore.
//		if (Physics.SphereCast(lightRay, 3f,out rayHit, 50f) && rayHit.collider.tag == "Player"){
//
//			playerPrefab.GetComponent<StealthPercent>().stealth = false;
//			
//		}
//		else{
//
//			playerPrefab.GetComponent<StealthPercent>().stealth = true;
//
//		}
	
	}
	
}
