using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Mob ))]
public class FirstPersonCameraControl : MonoBehaviour {

	public Vector2 sensitivity;
	public bool controlEnabled = false;
	public PhotographyManager cam;
	
	private Mob mb;
	private Rigidbody rbody;
	// Use this for initialization
	void Start () {
		mb = GetComponent<Mob>();
		rbody = GetComponent<Rigidbody>();
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
				cam.snap();
			}

//			Debug.Log( Input.GetAxis("Mouse X") + ", " + Input.GetAxis("Mouse Y") );
		}
		if( Input.GetAxis( "Open Camera" ) > 0 ) {
			if( controlEnabled ) {
				controlEnabled = false;
				GetComponent<OverheadPlayerControl>().controlEnabled = true;
				cam.switchToGame();
			} else {
				controlEnabled = true;
				GetComponent<OverheadPlayerControl>().controlEnabled = false;
				cam.switchToPhoto();
			}
		}
	}
}

