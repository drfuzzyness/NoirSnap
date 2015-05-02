using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Evidence ) ) ]
public class CollectableByPickup : MonoBehaviour {


	void OnTriggerEnter( Collider col ) {
		if( col.gameObject == ParticipantManager.instance.player ) {
			Debug.Log( gameObject.name + " is being picked up." );
			GetComponent<Evidence>().collect();
		}
	}
}
