using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Scanner) )]
public class ScannerDebugger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if( GetComponent<Scanner>().sees( GetComponent<Scanner>().target.gameObject ) ) {
//			Debug.Log ( gameObject + " sees" );
//		}
	}

	void OnDrawGizmos() {
		if( GetComponent<Scanner>().sees( ParticipantManager.instance.player ) ) {
			Gizmos.DrawLine( transform.position, ParticipantManager.instance.player.transform.position );
		}
	}
}
