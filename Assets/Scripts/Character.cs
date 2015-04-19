using UnityEngine;
using System.Collections;

// Every character in the game is of type Character. This has to due with determining innocence
public class Character : MonoBehaviour {
	
	[Header("State")]
	public bool oppinionOnInnocence = false; // Does the player think this person can be completly innocent

	[Header("Balance")]
	public bool innocent = true;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
