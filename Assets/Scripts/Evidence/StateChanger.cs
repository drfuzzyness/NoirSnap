using UnityEngine;
using System.Collections;

public class StateChanger : MonoBehaviour {

	public WalkOnRoute truck;


	public void StateChanged () {
	
		truck.startTransit();

	}

	// Update is called once per frame
	void Update () {
	
	}
}
