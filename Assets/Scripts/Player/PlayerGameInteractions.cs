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
		PlayerUIManager.instance.SeenByEnemy();
		
	}
	
	public void noLongerSeenBy( GameObject target ) {
		aggroed.Remove( target );
		Debug.Log("noLongerSeen() with " + aggroed.Count + " remaining");
		if( aggroed.Count == 0 ) {
			PlayerUIManager.instance.NoLongerSeen();
		}
		
	}
}
