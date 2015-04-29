using UnityEngine;
using System.Collections;

public class LightRaycast : MonoBehaviour {

	public Transform playerPrefab;
	public Transform boxPrefab;

	// Use this for initialization
	void Start () {

//		playerPrefab.GetComponent<StealthPercent>().stealth = true;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// ray from spotlight to the ground
		Ray lightRay = new Ray(transform.position, transform.forward);

		// gets a list of all the colliders the light ray is hitting
		// second and third parameters are tuned for a spotlight with a range of 50, spot angle of 50, and height of 5.35
		// Tune those parameters to fit the spotlight you make best
		RaycastHit[] obstacles = Physics.SphereCastAll (lightRay, 2.3f,50f);

		// goes through the list of colliders
		for (int i = 0; i < obstacles.Length; i++){

			// checks if one of the colliders hit is the Player
			if (obstacles[i].collider.tag == "Player"){

				// if one of them is the player, set the stealth status to false
				playerPrefab.GetComponent<StealthPercent>().isVisible = true;

				// HOWEVER, if the player is currently inside of a box then, they are considered HIDDEN even though they're in the spotlight's raycast
//				if (boxPrefab.GetComponent<Hidden>().inBox == true){
//					
//					playerPrefab.GetComponent<StealthPercent>().isVisible = false;
//					
//				}
				break;

			}

//			else{
//				playerPrefab.GetComponent<StealthPercent>().isVisible = false;
//
//			}



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
