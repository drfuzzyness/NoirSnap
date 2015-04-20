//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class guiltSystem : MonoBehaviour {
//	bool isGuilty = true;
//	public Color guiltyColor = Color.red;
//	public List <GameObject> GuiltyUntilProvenInnocent = new List<GameObject>();
//
//
//	string textBuffer = "Possible culprits will be in color.  As you eliminate suspects from the pool of possible culprits, they will fade to black.";
//
//
//
//	// Use this for initialization
//	void Start () {
//		//these are all the NPCs who start out as "guilty"
//		GuiltyUntilProvenInnocent.Add ("NPC1");
//		GuiltyUntilProvenInnocent.Add ("NPC2");
//		GuiltyUntilProvenInnocent.Add ("NPC3");
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//
//		if(Input.GetKeyDown(KeyCode.G)){  //action player takes to evaluate suspects
//
//			if (isGuilty == false) {
//				GuiltyUntilProvenInnocent.Remove("NPC1");
//				guiltyColor = Color.black;
//				textBuffer += "Suspect has been removed from your hitlist";
//			}
//		}
//	}
//}
