using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hidden : MonoBehaviour {
	
	public List<Collider> allColliders = new List<Collider> ();
	public Transform boxPrefab;     // assign STEALTHBOX to this in inspector
	public Transform playerPrefab;  // assign PLAYER to this in inspector

//	Vector3 curPos = new Vector3();



	// Use this for initialization
	void Start () {

		GetComponent<MeshRenderer>().enabled = false;
//		curPos = playerPrefab.transform.position;


	}
		
	// Update is called once per frame
	void Update () {

		foreach (var thisCollider in allColliders){
//		if (thingCurrentlyInside != null && boxPrefab.GetComponent<pickupItem>().inBox != true){
//			 if the player is inside of a box, then the spotlight doesn't see them
//				 make isVisible TRUE (ENEMY CAN SEE YOU!)
//			if (boxPrefab.GetComponent<pickupItem>().inBox == true){
//
//				break;
//			}
			if (thisCollider.tag == "Player"){

				if (boxPrefab.GetComponent<pickupItem>().inBox == true){
//					 if the player is in the box AND their current position does not equal the new position, make them visible to enemies and change their current position to the new one.
//					if (curPos != playerPrefab.transform.position){
//						thisCollider.GetComponent<PlayerVisibility>().isVisible = true;
//						curPos = playerPrefab.transform.position;
//					}
//					// if the current position and the new position are the same, then the player is not visible to enemies
//					else if (curPos == playerPrefab.transform.position){
//						thisCollider.GetComponent<PlayerVisibility>().isVisible = false;
//					}
					thisCollider.GetComponent<PlayerVisibility>().isVisible = false;
					break;
				}
				else{
					thisCollider.GetComponent<PlayerVisibility>().isVisible = true;
				}
			}
		}

	}
	
	// Unity automatically calls this function when an object using a Rigidbody
	// enters this object's trigger-collider AND it will tell you what entered it
	void OnTriggerEnter ( Collider activator ) {
		
		allColliders.Add(activator); // want to remember the thing that entered the trigger
		
	}
	
	void OnTriggerExit ( Collider exiter ) {
		// "null" means nothing, empty, anscence of anything
		allColliders.Remove(exiter);
		// Make isVisible FALSE (You're totally invisible)
		if (exiter.tag == "Player"){
		exiter.GetComponent<PlayerVisibility>().isVisible = false;
		}
	}
}
