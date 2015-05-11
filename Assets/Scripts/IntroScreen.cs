using UnityEngine;
using System.Collections;

public class IntroScreen : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if( Input.anyKeyDown ) {
			ParticipantManager.instance.player.GetComponent<FirstPersonCameraControl>().changeToGame();
			gameObject.SetActive( false );
		}
	}
}
