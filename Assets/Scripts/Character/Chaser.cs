using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ScanForTarget))]
public class Chaser : MonoBehaviour {

	public ParticipantManager participantManager; 

	private ScanForTarget scan;
	private WalkOnRoute router;

	// Use this for initialization
	void Start () {
		scan = GetComponent<ScanForTarget>();
		router = GetComponent<WalkOnRoute>();
	}
	
	// Update is called once per frame
	void Update () {
		if( scan.sees( participantManager.player ) ) {
			if( router != null ) {
				router.interrupt( true );
				scan.chase( participantManager.player );
			}
		}
	}
}
