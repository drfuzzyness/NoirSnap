using UnityEngine;
using System.Collections;

public class LightRaycast : MonoBehaviour {

	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray lightRay = new Ray(transform.position, transform.forward);

		RaycastHit[] obstacles = Physics.SphereCastAll (lightRay, 2.3f,50f);

		for (int i = 0; i < obstacles.Length; i++){

			if (obstacles[i].collider.tag == "Player"){

				playerPrefab.GetComponent<StealthPercent>().stealth = false;
				break;

			}
			else{
				
				playerPrefab.GetComponent<StealthPercent>().stealth = true;
				
			}

		}
//		if (Physics.SphereCast(lightRay, 3f,out rayHit, 50f) && rayHit.collider.tag == "Player"){
//
//			playerPrefab.GetComponent<StealthPercent>().stealth = false;
//			
//		}
//		else{
//
//			playerPrefab.GetComponent<StealthPercent>().stealth = true;
//
//		}
	
	}
	
}
