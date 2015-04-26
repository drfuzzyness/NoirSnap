using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Mob))]
public class Scanner : MonoBehaviour {

	public Mob target;

	[Header("State")]
	public bool aggressing;
	public bool hasCaughtTarget;

	[Header("Balance")]
	public float sightRange;
	public float visionConeAngle;

	private WalkOnRoute walker;


	public bool sees( GameObject target ){
		Vector3 vectorToPlayer = target.transform.position - transform.position;
		bool isCloseEnough = vectorToPlayer.magnitude < sightRange;
		bool isInViewCone = false;
		if( isCloseEnough ) {
//			Debug.Log( target + " is close enough" );
			isInViewCone = Mathf.Abs ( ( Vector3.Dot( transform.forward, vectorToPlayer.normalized ) - 1) * 180 ) < visionConeAngle;
			if( isInViewCone ) {
//				Debug.Log( target + " is in view cone enough" );
				Ray LOSRay = new Ray( transform.position, vectorToPlayer.normalized );
				RaycastHit LOSRayHit = new RaycastHit();
				if(  Physics.Raycast( LOSRay, out LOSRayHit, sightRange ) && LOSRayHit.collider.gameObject == target ) {
//					Debug.Log( target + " is in LOS" );
					return true;
				} else {
					return false;
				}
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	public void aggro( GameObject theTarget ) {
		if( !aggressing ) {
			Debug.Log( "Starting Aggro" );
			aggressing = true;
			SendMessage( "startAggro", theTarget );
			walker.interrupt();
		}
	}

	public void deaggro() {
		if( aggressing ) {
			Debug.Log( "Stopping Aggro" );
			aggressing = false;
			SendMessage( "stopAggro" );
			walker.startTransit();
		}
	}



	// Use this for initialization
	void Start () {
		walker = GetComponent<WalkOnRoute>();
	}
	
	// Update is called once per frame
	void Update () {
		if( sees( target.gameObject ) ) {
			if( GetComponent<WalkOnRoute>() != null ) {
				GetComponent<WalkOnRoute>().interrupt( true );
				aggro( target.gameObject );
			}
		}
	}
}
