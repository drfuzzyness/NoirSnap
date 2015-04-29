using UnityEngine;
using System.Collections;

public class PlayOnPhotographed : MonoBehaviour {

	public Dialogue dialogue;

	public void OnPhotographed() {
		dialogue.play();
	}
}
