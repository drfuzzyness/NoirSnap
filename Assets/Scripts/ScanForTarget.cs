using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Mob))]
public class ScanForTarget : MonoBehaviour {

	public Mob player;

	[Header("State")]
	public bool chasing;
	public bool hasCaughtTarget;

	[Header("Balance")]
	public float sightRange;
	public float visionConeAngle;
	public float catchRange;

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

	public void chase( GameObject target ) {
		if( !chasing ) {
			Debug.Log ("chasing " + target );
			chasing = true;
			GetComponent<Mob>().run();
			StartCoroutine( "tryToCatch", target );
		}

	}

	IEnumerator tryToCatch( GameObject target ) {
		while( chasing && sees ( target ) ) {
			Vector3 vectorToHunted = target.transform.position - transform.position;
			GetComponent<Mob>().turnToFace( target.transform );
			GetComponent<Mob>().run();
			if(  vectorToHunted.magnitude < catchRange ) {
				target.SendMessage( "caught" );

				stopChasing();
			}
			yield return null;
//			try {
//				string garbage = target.name;
//			} catch {
//				stopChasing();
//			}
		}
		target.SendMessage("calm");
		stopChasing();

	}

	public void stopChasing() {
		chasing = false;
		GetComponent<Mob>().walk();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
