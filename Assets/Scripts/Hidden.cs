using UnityEngine;
using System.Collections;

public class Hidden : MonoBehaviour {

	Collider thingCurrentlyInside;
	public bool inBox = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// if there is a thing currently inside this trigger...
		if (thingCurrentlyInside != null){
			// make it's hidden stealth value TRUE (It's totally hiding, bro.)
			thingCurrentlyInside.GetComponent<StealthPercent>().stealth = true;
			// This is for the LightRaycast script. So if the player is inside a box inside of a lightraycast, then they're considered hidden 
			inBox = true;

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
		inBox = false;
		
	}
}
