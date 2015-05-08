using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Mob ))]
public class FirstPersonCameraControl : MonoBehaviour {

	public Vector2 sensitivity;
	public bool controlEnabled = false;
	public bool startInFirstPerson;
	public PhotographyManager cam;
	
//	private Mob mb;
//	private Rigidbody rbody;
	// Use this for initialization
	void Start () {
//		mb = GetComponent<Mob>();
//		rbody = GetComponent<Rigidbody>();
		if( startInFirstPerson ) {
			changeToCam( false );
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( controlEnabled ) {
			cam.transform.Rotate( -Input.GetAxis("Mouse Y") * sensitivity.y, Input.GetAxis("Mouse X") * sensitivity.x , 0f );
			Vector3 tempRot = cam.transform.localEulerAngles;
			tempRot.z = 0f;
			Camera.main.transform.localEulerAngles = tempRot;
			cam.transform.localEulerAngles = tempRot;
			if( Input.GetAxis( "Take Photo" ) > 0 ) {
				Debug.Log("trying to snap.");
				cam.snap();
			}

//			Debug.Log( Input.GetAxis("Mouse X") + ", " + Input.GetAxis("Mouse Y") );
		}
		if( Input.GetAxis( "Open Camera" ) > 0 ) {
			if( controlEnabled && !cam.inTransition ) {
				changeToGame();
			} else if( !controlEnabled && !cam.inTransition ) {
				changeToCam();
			}
		}
	}

	public void changeToGame() {
		if( cam.inTransition )
			return;
		Cursor.lockState = CursorLockMode.Confined;


		cam.switchToGame();
		GetComponent<OverheadPlayerControl>().controlEnabled = false;
		StartCoroutine( "waitToChangeControl", false );
	}
	

	public void changeToCam( bool rotateToMouse = true) {
		if( cam.inTransition )
			return;
		if( rotateToMouse ) {
			Ray rayToMousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit = new RaycastHit();
			if( Physics.Raycast( rayToMousePos, out rayHit ) ) {
				cam.transform.LookAt( rayHit.point );
			}
		}
		controlEnabled = false;
		cam.switchToPhoto();
		Cursor.lockState = CursorLockMode.Locked;
		StartCoroutine( "waitToChangeControl", true );
	}

	IEnumerator waitToChangeControl( bool changeTo ) {
		yield return new WaitForSeconds (cam.transitionTime );
		controlEnabled = changeTo;
		GetComponent<OverheadPlayerControl>().controlEnabled = !changeTo;
	}
}

