using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Character)) ]
// Things that aren't characters could be killable. Like shooting pidgeons or doves.
public class Damageable : MonoBehaviour {

	[Header("Status")]
	public float health; // summary of current health including diet, cancers, physical injury
	public bool alive = true; // possibly innacurate simulation of life. can things be half-dead?

	[Header("Balance")]
	public float startingHealth = 10f; // mostly genetic, partially based on "free will" of the character.
	public bool isCharacter; // check if the damageable object is a character


	
	public void kill() { // is kill
		
	}

	public void damage( float dmg ) {
		health -= dmg;
		if( !isAlive() )
			kill();
	}

	public bool isAlive() {
		return health > 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
