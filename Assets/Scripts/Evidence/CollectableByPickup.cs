using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Evidence ) ) ]
public class CollectableByPickup : MonoBehaviour {

	public ParticipantManager participantManager;

	void OnTriggerEnter( Collider col ) {
		if( col.gameObject == participantManager.player ) {
			Debug.Log( gameObject.name + " is being picked up." );
			GetComponent<Evidence>().collect();
		}
	}
}
