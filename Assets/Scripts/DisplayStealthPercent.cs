using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayStealthPercent : MonoBehaviour {

	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		string textBuffer = "";

		textBuffer = "The Enemy Can See You: " + playerPrefab.GetComponent<StealthPercent>().isVisible.ToString();

		GetComponent<Text>().text = textBuffer;

	}
}
