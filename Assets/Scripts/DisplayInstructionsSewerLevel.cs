using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayInstructionsSewerLevel : MonoBehaviour {
	public Text text;

	// Use this for initialization
	void Start () {

		text.text = "Find the Giant Sphere.\n THE SPHERE IS GOOD.";

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.W)){

			text.text = "";

		}


	
	}
}
