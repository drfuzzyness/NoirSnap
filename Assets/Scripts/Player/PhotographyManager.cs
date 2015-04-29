using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhotographyManager : MonoBehaviour {

	[Header("Status")]
	public bool inPhotographyMode;
	public bool inTransition;

	[Header("Balance")]
	public float sightRange;
	public float fieldOfView;
	public float transitionTime;
	
	[Header("Setup")]

	public Camera mainCamera;
	public Transform mainCameraPositionObject;
	public AnimationCurve transition;
	public ParticipantManager participantManager;






	public void switchToPhoto() {
//		iTween.CameraFadeTo( 1f, transitionTime );
		StartCoroutine( switchToPhotoWait() );
	}

	public void switchToGame() {
//		iTween.CameraFadeTo( 0f, transitionTime/2 );
		StartCoroutine( switchToGameWait() );
	}

	public void snap() {
		foreach( Photographable thisObj in participantManager.photographables ) {
			if( canSee( thisObj.transform ) ) {
				Debug.Log( gameObject.name + " sees " + thisObj.gameObject.name );
				thisObj.SendMessage( "OnPhotographed" ); // Calls all functions in all components on the object with name void OnPhotographed()
			} else {
//				Debug.Log( gameObject.name + " can't see " + thisObj.gameObject.name );
			}
		}
	}

	bool canSee( Transform target ) {
		Vector3 vectorToTarget = target.position - transform.position;
		bool isCloseEnough = vectorToTarget.magnitude < sightRange;
		bool isInViewCone = false;
		if( isCloseEnough ) {
			//			Debug.Log( target + " is close enough" );
			isInViewCone = Vector3.Angle( transform.forward, target.position ) < fieldOfView;
			if( isInViewCone ) {
				//				Debug.Log( target + " is in view cone enough" );
				Ray LOSRay = new Ray( transform.position, vectorToTarget.normalized );
				RaycastHit LOSRayHit = new RaycastHit();
				if(  Physics.Raycast( LOSRay, out LOSRayHit, sightRange ) && LOSRayHit.collider.gameObject == target.gameObject ) {
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

	IEnumerator switchToPhotoWait() {
		inTransition = true;
		iTween.CameraFadeTo( 1f, transitionTime/2 );
		iTween.MoveTo( mainCamera.gameObject, transform.position, transitionTime );
		iTween.RotateTo( mainCamera.gameObject, transform.eulerAngles, transitionTime );
		yield return new WaitForSeconds( transitionTime/2 );
//		mainCamera.transform.position = transform.position;
//		mainCamera.transform.rotation = transform.rotation;
		iTween.CameraFadeTo( 0f, transitionTime/2 );
		yield return new WaitForSeconds( transitionTime/2 );
		inPhotographyMode = true;
		inTransition = false;
	}

	IEnumerator switchToGameWait() {
		inTransition = true;
		inPhotographyMode = false;
		iTween.MoveTo( mainCamera.gameObject, mainCameraPositionObject.position, transitionTime );
		iTween.RotateTo( mainCamera.gameObject, mainCameraPositionObject.eulerAngles, transitionTime );
		iTween.CameraFadeTo( 1f, transitionTime/2 );
		yield return new WaitForSeconds( transitionTime/2 );
//		mainCamera.transform.position = mainCameraPositionObject.position;
//		mainCamera.transform.rotation = mainCameraPositionObject.rotation;
		iTween.CameraFadeTo( 0f, transitionTime/2 );
		yield return new WaitForSeconds( transitionTime/2 );
		inTransition = false;
	}

	// Use this for initialization
	void Start () {
		iTween.CameraFadeAdd();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
