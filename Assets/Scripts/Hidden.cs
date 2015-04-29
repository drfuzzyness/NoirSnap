using UnityEngine;
using System.Collections;

public class Hidden : MonoBehaviour {

	Collider thingCurrentlyInside;

	public Transform playerPrefab;   // Assign this in the inspector, then use 'Apply' button to make this the case for all spotlights in the level
	public Transform boxPrefab;      // this should already be assigned in inspector, but if not, assign StealthBox in this spot. Use 'Apply' to affect all spotlights.


	// Use this for initialization
	void Start () {

		GetComponent<MeshRenderer>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		// if there is a thing currently inside this trigger...
		if (thingCurrentlyInside != null){
			// if the player is inside of a box, then the spotlight doesn't see them
//			if (boxPrefab.GetComponent<pickupItem>().inBox == true){
//				playerPrefab.GetComponent<StealthPercent>().isVisible = false;
//			}
//			else{
				// make isVisible TRUE (ENEMY CAN SEE YOU!)
			thingCurrentlyInside.GetComponent<StealthPercent>().isVisible = true;
//			}


		}

		
	}
	
	// Unity automatically calls this function when an object using a Rigidbody
	// enters this object's trigger-collider AND it will tell you what entered it
	void OnTriggerEnter ( Collider activator ) {
		
		thingCurrentlyInside = activator; // want to remember the thing that entered the trigger
		
	}
	
	void OnTriggerExit ( Collider exiter ) {
		// "null" means nothing, empty, anscence of anything
		thingCurrentlyInside = null;
		// Make isVisible FALSE (You're totally invisible)
		playerPrefab.GetComponent<StealthPercent>().isVisible = false;

		
	}
}
