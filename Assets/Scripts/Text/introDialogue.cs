using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class introDialogue : MonoBehaviour {
	public Text text;
	public Text text2;
	public Text cont;
	int count1 = 0;
	int count2 = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			count1 += 1;
			count2 += 1;
		}
		if (count1 == 0){
		
		}
		if (count1 == 1){
		
		}
	}
}
