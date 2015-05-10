﻿using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Mob ))]
public class OverheadPlayerControl : MonoBehaviour {

	public bool controlEnabled = true;
	public bool isMoving;

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
			Vector3 movement = transform.right * mb.walkSpeed * Time.deltaTime * Input.GetAxis( "Horizontal" )
								 + transform.forward * mb.walkSpeed * Time.deltaTime * Input.GetAxis( "Vertical" );
			rbody.MovePosition( transform.position + movement.normalized * mb.walkSpeed * Time.deltaTime );
			isMoving = true;
		}
		else {
			isMoving = false;
		}
	}
}
