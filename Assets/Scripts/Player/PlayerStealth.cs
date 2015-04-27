using UnityEngine;
using System.Collections;

public class PlayerStealth : MonoBehaviour {

	public float maxDelayBeforeAggro;

	private bool canBeSeen;
	private bool inDirectSight;
	private bool transitioning;
	private bool inStealth;
	public float stealthPercent;

	public bool isInStealth() {
		return inStealth;
	}

	public void seenBy( GameObject spotter ) {
		Debug.Log( "SEEN!" );
		Scanner scan = spotter.GetComponent<Scanner>();
		Vector3 distance = spotter.transform.position - transform.position;
		float maxDistance = scan.sightRange;
		StartCoroutine( "beingSeen", (distance.magnitude / maxDistance) * maxDelayBeforeAggro );
	}

	public void noLongerSeenBy( GameObject spotter ) {
		inStealth = false;
		transitioning = false; // interupts the being seen progression
		// unapply camera effects
	}

	IEnumerator beingSeen( float delay ) {
		transitioning = true;
		for( float timer = 0f; timer < delay && transitioning; timer += Time.deltaTime ) {
		    // apply camera effects
			yield return null;
		}
		if( !transitioning )
			yield break;
		transitioning = false;
		inStealth = true;
		Debug.Log( "AHHH HE SEES ME" );
	}

	// Use this for initialization
	void Start () {
		inStealth = false;
	}
}
