using UnityEngine;
using System.Collections;

public class WinOnCollect : MonoBehaviour {

	// Use this for initialization
	public void OnPhotographed() {
		Debug.Log("WIN!");
		LevelManager.instance.playerWon();
	}
}
