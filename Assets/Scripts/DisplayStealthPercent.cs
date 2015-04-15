using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DisplayStealthPercent : MonoBehaviour {

	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		string textBuffer = "";

		textBuffer = "Hidden: " + playerPrefab.GetComponent<StealthPercent>().stealth.ToString();

		GetComponent<Text>().text = textBuffer;

	}
}
