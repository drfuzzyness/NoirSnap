using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ScanForTarget) )]
public class ScannerDebugger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( GetComponent<ScanForTarget>().sees( GetComponent<ScanForTarget>().target.gameObject ) ) {
			Debug.Log ( gameObject + " sees" );
		}
	}
}
