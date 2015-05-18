using UnityEngine;
using System.Collections;

public class ExitTruck : MonoBehaviour {

	public WalkOnRoute truck;

	// Use this for initialization
	void Awake () {
	
		truck = GetComponent<WalkOnRoute>();

	}

	public void StateChanged (){
	
		truck.startInTransit = true;

	}

	// Update is called once per frame
	void Update () {
	
	}
}
