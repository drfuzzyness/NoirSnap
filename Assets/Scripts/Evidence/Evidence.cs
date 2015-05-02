using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Evidence : MonoBehaviour {

	[Header("Status")]
	public bool collected = false;

	public float value = 0f;
	[Header("Setup")]
	public bool hideOnCollect = false;
	public List<GameObject> informOnCollect;

	public void collect() {

		if( !collected ) {
			gameObject.SendMessage( "OnCollected" );
			foreach( GameObject thisObj in informOnCollect ) {
				thisObj.SendMessage( "OnCollected" );
			}
			if( hideOnCollect ) {
				gameObject.SetActive( false );
			}
			collected = true;
		} else {
			Debug.LogWarning( gameObject.name + " has already been collected." );
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
