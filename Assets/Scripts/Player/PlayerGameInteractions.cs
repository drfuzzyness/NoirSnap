using UnityEngine;
using System.Collections;

public class PlayerGameInteractions : MonoBehaviour {
	

	public void deathByLossOfLife() {
		LevelManager.instance.playerDied();
	}

	public void caught( GameObject catcher = null) {
		LevelManager.instance.playerCaught();
	}
}
