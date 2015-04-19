using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Mob))]
public class WalkOnRoute : MonoBehaviour {

	public RouteWaypoint nextWayPoint;
	public bool startInTransit;
	public bool keepMoving;

	[Header("State")]
	public bool inTransit;
	public bool allowInterruption;

//	[Header("Config")]

	private Mob mob;

	public void startTransit() {
		if( nextWayPoint == null ) {
			Debug.LogError( gameObject + " doesn't have a next waypoint." );
			return;
		}
		inTransit = true;
		StartCoroutine( transit() );
	}

	IEnumerator transit() {
		mob.turnToFace( nextWayPoint.transform );
		mob.walk();
		while( inTransit ) {
			yield return null;
		}
	}

	public void interrupt( bool forceInterruption = false ) {
		if( allowInterruption || forceInterruption ) {
			StopCoroutine( transit() );
		}
	}

	public void setWaypoint( RouteWaypoint next ) {
		if( inTransit ) {
			interrupt( true );
		}
		nextWayPoint = next;
	}

	public void arrived() {
		inTransit = false;
		mob.stop();
	}

	void OnDrawGizmos() {
		if( nextWayPoint != null ) {
			Vector3 vectToNext = nextWayPoint.transform.position - transform.position;
			Gizmos.DrawRay( transform.position, vectToNext);
		}
	}

	// Use this for initialization
	void Start () {
		mob = GetComponent<Mob>();
		if( startInTransit ){
			startTransit();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
