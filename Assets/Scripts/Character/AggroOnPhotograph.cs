﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Scanner))]
public class AggroOnPhotograph : MonoBehaviour {
	public void OnPhotographed() {
		GetComponent<Scanner>().aggro( GetComponent<Scanner>().target.gameObject );
	}
}