using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Scanner))]
public class Chaser : MonoBehaviour {

//	public ParticipantManager participantManager;
	public float catchRange;
	public float delayBeforeChase;
	public float delayAfterChase;
	public List<GameObject> informOnVision;
	public GameObject lastSeenMarkerPrefab;

	private GameObject lastSeen;
	private Scanner scan;
	private WalkOnRoute router;
	private Mob mb;

	public void startAggro( GameObject target ) {
			Debug.Log ( gameObject.name + " is chasing " + target );
			scan.aggressing = true;
//			GetComponent<Mob>().run();
			StartCoroutine( "chase", target );
	}

	public void stopAggro() {
		scan.aggressing = false;
		mb.walk();
		StopCoroutine( "chase" );
	}

	IEnumerator chase( GameObject target ) {
		while( scan.aggressing && scan.sees ( target ) ) {
			Vector3 vectorToHunted = target.transform.position - transform.position;
			mb.setDestination( target.transform.position );
			mb.run();
			if(  vectorToHunted.magnitude < catchRange ) {
				Debug.Log( gameObject.name + " has caught " + target.name );
				target.SendMessage( "caught", gameObject );
				
				stopAggro();
			}
			yield return null;
		}
//		target.SendMessage("calm");
		StartCoroutine( "chaseToLastVisible", target );
		
	}

	IEnumerator chaseToLastVisible( GameObject target ) {
		Vector3 targetPos = target.transform.position;
		lastSeen = Instantiate( lastSeenMarkerPrefab, targetPos, transform.rotation * Quaternion.Euler( 90f, 0f, 0f ) ) as GameObject;
		mb.setDestination( target.transform.position );
		while( GetComponent<NavMeshAgent>().remainingDistance > 0.01f ) {
			if( scan.sees( target ) ) {
				startAggro( target );
				Destroy( lastSeen );
				yield break;
			}
			yield return null;
		}
		yield return new WaitForSeconds( delayAfterChase );
		scan.deaggro();
		Destroy( lastSeen );
	}

	// Use this for initialization
	void Start () {
		scan = GetComponent<Scanner>();
		router = GetComponent<WalkOnRoute>();
		mb = GetComponent<Mob>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
