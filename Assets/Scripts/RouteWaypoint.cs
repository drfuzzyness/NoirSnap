using UnityEngine;
using System.Collections;


public class RouteWaypoint : MonoBehaviour {

	public RouteWaypoint next;
	public float delay = 0f;

	void OnDrawGizmos() {
		if( next != null ) {
			Vector3 vectToNext = next.transform.position - transform.position;
			Gizmos.DrawRay( transform.position, vectToNext);
		}
//		Gizmos.DrawWireSphere( transform.position, .4f );
	}

	void OnTriggerEnter( Collider col ) {
		if( col.gameObject.GetComponent<WalkOnRoute>().isActiveAndEnabled 
		   && col.gameObject.GetComponent<WalkOnRoute>().nextWayPoint == this ) {
			arrived( col.gameObject.GetComponent<WalkOnRoute>() );
		}
	}

	void arrived( WalkOnRoute walker ) {
		StartCoroutine( "applyDelay" , walker );
	}

	IEnumerator applyDelay( WalkOnRoute walker ) {
		if( walker.arrived() ) {
			yield return new WaitForSeconds( delay );
			walker.setWaypoint( next );
			if( walker.keepMoving ) {
				walker.startTransit();
			}
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
