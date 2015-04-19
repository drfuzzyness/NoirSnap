using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Evidence ) ) ]
[RequireComponent( typeof( Photographable ) ) ]
public class CollectableByPhoto : MonoBehaviour {

	public void photographed() {
		Debug.Log( gameObject.name + " is being photographed." );
		GetComponent<Evidence>().collect();
	}
}
