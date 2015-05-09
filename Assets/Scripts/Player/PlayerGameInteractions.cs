using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGameInteractions : MonoBehaviour {
	
	public List<GameObject> aggroed;

	public void deathByLossOfLife() {
		LevelManager.instance.playerDied();
	}

	public void caught( GameObject catcher = null) {
		LevelManager.instance.playerCaught();
	}
	
	public void seenBy( GameObject target ) {
		aggroed.Add( target );
		
	}
	
	public void noLongerSeenBy( GameObject target ) {
		aggroed.Remove( target );
	}
}
