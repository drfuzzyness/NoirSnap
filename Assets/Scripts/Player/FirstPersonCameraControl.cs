using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Mob ))]
public class FirstPersonCameraControl : MonoBehaviour {

	public float sensitivity;
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
			cam.transform.Rotate( Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f );
		}
		if( Input.GetAxis( "OpenCam" ) > 0 ) {
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

