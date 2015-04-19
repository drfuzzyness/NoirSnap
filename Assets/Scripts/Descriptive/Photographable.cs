using UnityEngine;
using System.Collections;

public class Photographable : MonoBehaviour {

	[Header("Status")]
	public bool seen = false;

	// Use this for initialization
	void Start () {
		seen = false;
	}

	void photographed() {
		if( !seen ) {
			seen = true;
		} else {
			Debug.Log( gameObject.name + " has already been photographed " );
		}
	}

}
