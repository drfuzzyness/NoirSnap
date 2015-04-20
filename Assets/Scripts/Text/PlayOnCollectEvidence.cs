using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Dialogue ) ) ]
public class PlayOnCollectEvidence : MonoBehaviour {
	public void OnCollected() {
		GetComponent<Dialogue>().play();
	}
}
