using UnityEngine;
using System.Collections;

public class PlayerVisibility : MonoBehaviour {

	public bool isVisible = true;
	public static PlayerVisibility instance;

	// Use this for initialization
	void Start () {
		isVisible = false;

	
	}

	void Awake (){
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {




	
	}
}
