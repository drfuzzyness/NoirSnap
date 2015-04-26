using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Scanner))]
public class Chaser : MonoBehaviour {

//	public ParticipantManager participantManager;
	public float catchRange;
	public float delayBeforeChase;
	public List<GameObject> informOnVision;

	private Scanner scan;
	private WalkOnRoute router;

	public void startAggro( GameObject target ) {
			Debug.Log ( gameObject.name + " is chasing " + target );
			scan.aggressing = true;
			GetComponent<Mob>().run();
			StartCoroutine( "chase", target );
	}

	public void stopAggro() {
		scan.aggressing = false;
		GetComponent<Mob>().walk();
		StopCoroutine( "chase" );
	}

	IEnumerator chase( GameObject target ) {
		while( scan.aggressing && scan.sees ( target ) ) {
			Vector3 vectorToHunted = target.transform.position - transform.position;
			GetComponent<Mob>().turnToFace( target.transform );
			GetComponent<Mob>().run();
			if(  vectorToHunted.magnitude < catchRange ) {
				Debug.Log( gameObject.name + " has caught " + target.name );
				target.SendMessage( "caught", gameObject );
				
				stopAggro();
			}
			yield return null;
		}
//		target.SendMessage("calm");
		scan.deaggro();
		
	}

	// Use this for initialization
	void Start () {
		scan = GetComponent<Scanner>();
		router = GetComponent<WalkOnRoute>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
