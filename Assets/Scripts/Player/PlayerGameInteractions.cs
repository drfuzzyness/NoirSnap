using UnityEngine;
using System.Collections;

public class PlayerGameInteractions : MonoBehaviour {

	public LevelManager levelMan;

	public void deathByLossOfLife() {
		levelMan.playerDied();
	}

	public void caught( GameObject catcher = null) {
		levelMan.playerCaught();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
