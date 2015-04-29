using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Mob))]
public class Scanner : MonoBehaviour {

	public Mob target;
	public PlayerVisibility stealth;

	[Header("State")]
	public bool aggressing;
	public bool hasCaughtTarget;
	public float sightRange;

	[Header("Balance")]
	public bool requireLightToSee;
	public bool onlyAggroIfCanBeSeen;
	public float baseSightRange;
	public float spotlightSightRange;
	public float visionConeAngle;

	private WalkOnRoute walker;


	public bool sees( GameObject target ){

		if( onlyAggroIfCanBeSeen && !GetComponent<Renderer>().isVisible )
			return false;
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
			target.SendMessage( "seenBy", gameObject );
			SendMessage( "startAggro", theTarget );
			walker.interrupt();
		}
	}

	public void deaggro() {
		if( aggressing ) {
			Debug.Log( "Stopping Aggro" );
			aggressing = false;
			target.SendMessage( "noLongerSeenBy", gameObject );
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
		if( requireLightToSee && !stealth.isVisible ) {
			sightRange = baseSightRange;
		} else if ( requireLightToSee && stealth.isVisible ) {
			sightRange = spotlightSightRange;
		}
		if( !aggressing && sees( target.gameObject ) ) {
			if( GetComponent<WalkOnRoute>() != null ) {
				GetComponent<WalkOnRoute>().interrupt( true );
			}
			aggro( target.gameObject );
		}
	}
}
