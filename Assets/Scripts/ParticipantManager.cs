using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticipantManager : MonoBehaviour {
	
	public GameObject player;
	public List<Character> characters;
	public List<Photographable> photographables;
	public static ParticipantManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
}
