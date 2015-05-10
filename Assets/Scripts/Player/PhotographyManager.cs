using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class PhotographyManager : MonoBehaviour {

	[Header("Status")]
	public bool inPhotographyMode;
	public bool inTransition;
	public List<Texture> screenshots;

	[Header("Balance")]
	public float sightRange;
	public float fieldOfView;
	public float transitionTime;
	
	[Header("Setup")]
	public bool hidePlayerOnEnter = true;	
	public Camera mainCamera;
	public Transform mainCameraPositionObject;
	public AnimationCurve transition;
// 	public ParticipantManager participantManager;






	public void switchToPhoto() {
//		iTween.CameraFadeTo( 1f, transitionTime );
		StartCoroutine( switchToPhotoWait() );
	}

	public void switchToGame() {
//		iTween.CameraFadeTo( 0f, transitionTime/2 );
		StartCoroutine( switchToGameWait() );
	}

	public void Snap() {
		if( PlayerUIManager.instance.isFlashing )
			return;
		StartCoroutine( TakeScreenshot() );
		foreach( Photographable thisObj in ParticipantManager.instance.photographables ) {
			PlayerUIManager.instance.CueCameraFlash();
// 			Debug.Log("grying to snap " + thisObj);
			if( CanSee( thisObj.transform ) ) {
				Debug.Log( gameObject.name + " sees " + thisObj.gameObject.name );
				thisObj.SendMessage( "OnPhotographed" ); // Calls all functions in all components on the object with name void OnPhotographed()
			} else {
				Debug.Log( gameObject.name + " can't see " + thisObj.gameObject.name );
			}
		}
	}

	bool CanSee( Transform target ) {
		Vector3 vectorToTarget = target.position - transform.position;
		bool isCloseEnough = vectorToTarget.magnitude < sightRange;
		bool isInViewCone = false;
		if( isCloseEnough ) {
						Debug.Log( target + " is close enough" );
			isInViewCone = Vector3.Angle( transform.forward, target.position ) < fieldOfView;
			if( isInViewCone ) {
								Debug.Log( target + " is in view cone enough" );
				Ray LOSRay = new Ray( transform.position, vectorToTarget.normalized );
				RaycastHit LOSRayHit = new RaycastHit();
				if(  Physics.Raycast( LOSRay, out LOSRayHit, sightRange ) && LOSRayHit.collider.gameObject == target.gameObject ) {
										Debug.Log( target + " is in LOS" );
					return target.GetComponent<MeshRenderer>().isVisible;
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
		if( hidePlayerOnEnter ) {
			ParticipantManager.instance.player.GetComponent<MeshRenderer>().enabled = false;
		}	
// 		ParticipantManager.instance.player.GetComponent<Collider>().enabled = false;
		inTransition = true;
		iTween.CameraFadeTo( 1f, transitionTime/2 );
		iTween.MoveTo( mainCamera.gameObject, transform.position, transitionTime );
		iTween.RotateTo( mainCamera.gameObject, transform.eulerAngles, transitionTime );
		yield return new WaitForSeconds( transitionTime/2 );
//		mainCamera.transform.position = transform.position;
//		mainCamera.transform.rotation = transform.rotation;
		iTween.CameraFadeTo( 0f, transitionTime/2 );
		PlayerUIManager.instance.noiseAndGrainEnabled = true;
		yield return new WaitForSeconds( transitionTime/2 );
		inPhotographyMode = true;
		inTransition = false;
	}

	IEnumerator switchToGameWait() {
		ParticipantManager.instance.player.GetComponent<MeshRenderer>().enabled = true;
// 		ParticipantManager.instance.player.GetComponent<Collider>().enabled = true;
		inTransition = true;
		inPhotographyMode = false;
		iTween.MoveTo( mainCamera.gameObject, mainCameraPositionObject.position, transitionTime );
		iTween.RotateTo( mainCamera.gameObject, mainCameraPositionObject.eulerAngles, transitionTime );
		iTween.CameraFadeTo( 1f, transitionTime/2 );
		yield return new WaitForSeconds( transitionTime/2 );
//		mainCamera.transform.position = mainCameraPositionObject.position;
//		mainCamera.transform.rotation = mainCameraPositionObject.rotation;
		PlayerUIManager.instance.noiseAndGrainEnabled = false;
		iTween.CameraFadeTo( 0f, transitionTime/2 );
		yield return new WaitForSeconds( transitionTime/2 );
		inTransition = false;
	}
	
	IEnumerator TakeScreenshot()
    {
        // wait for graphics to render
		Application.CaptureScreenshot( Time.time.ToString() + Time.unscaledTime.ToString() + ".png" );
        yield return new WaitForEndOfFrame();
 
        // create a texture to pass to encoding
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
 
        // put buffer into texture
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
 
        // split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
        yield return 0;
		screenshots.Add( texture );
//         byte[] bytes = texture.EncodeToPNG();
//  
//         // save our test image (could also upload to WWW)
//         File.WriteAllBytes(Application.dataPath + "/../testscreen-" + count + ".png", bytes);
//         count++;
//  
//         // Added by Karl. - Tell unity to delete the texture, by default it seems to keep hold of it and memory crashes will occur after too many screenshots.
//         DestroyObject( texture );
//  
//         //Debug.Log( Application.dataPath + "/../testscreen-" + count + ".png" );
    }

	// Use this for initialization
	void Start () {
		iTween.CameraFadeAdd();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
