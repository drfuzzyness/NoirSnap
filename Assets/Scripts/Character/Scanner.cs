using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Mob))]
public class Scanner : MonoBehaviour {


//	public PlayerVisibility stealth;

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
	private Mob target;
	private Collider boxTarget;

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
				if(  Physics.Raycast( LOSRay, out LOSRayHit, sightRange ) && (LOSRayHit.collider.gameObject == target || LOSRayHit.collider.gameObject == boxTarget)) {
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
			GetComponent<Renderer>().material.color = Color.red;

			Debug.Log( "Starting Aggro" );
			aggressing = true;
			theTarget.SendMessage( "seenBy", gameObject );
			SendMessage( "startAggro", theTarget );
			walker.interrupt();
		}
	}

	public void deaggro() {
		if( aggressing ) {
			GetComponent<Renderer>().material.color = Color.blue;

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
		target = ParticipantManager.instance.player.GetComponent<Mob>();
		boxTarget = ParticipantManager.instance.box.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if( requireLightToSee && !PlayerVisibility.instance.isVisible ) {
			sightRange = baseSightRange;
		} else if ( requireLightToSee && PlayerVisibility.instance.isVisible ) {
			sightRange = spotlightSightRange;
		}
//			else if (requireLightToSee && pickupItem.instance.isMoving){
//			sightRange = baseSightRange;
//		}else if (requireLightToSee && (pickupItem.instance.inBox && !pickupItem.instance.isMoving)){
//			sightRange = 0f;
//		}

		if( !aggressing && sees( target.gameObject )) {
			if( GetComponent<WalkOnRoute>() != null ) {
				GetComponent<WalkOnRoute>().interrupt( true );
			}
			aggro( target.gameObject );
		}else if (!aggressing && (sees(boxTarget.gameObject) && pickupItem.instance.isMoving)){
			if( GetComponent<WalkOnRoute>() != null ) {
				GetComponent<WalkOnRoute>().interrupt( true );
			}
			aggro( boxTarget.gameObject );
		}
	}
}
