﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


	public float minDurationOfGameoverScreen;
	public GameObject gameoverScreen;
	public GameObject playerVictoryScreen;

	public int nextLevelIndex;

	public void playerCaught( ) {
		StartCoroutine( gameoverScene() );
	}

	public void playerDied() {
		StartCoroutine( gameoverScene() );
	}

	public void playerWon() {
		StartCoroutine( playerVictoryScene() );
	}

	IEnumerator gameoverScene() {
		gameoverScreen.SetActive( true );
		yield return new WaitForSeconds( minDurationOfGameoverScreen );
		while( !Input.anyKeyDown ) {
			yield return null;
		}
		Application.LoadLevel( Application.loadedLevel );
	}

	IEnumerator playerVictoryScene() {
		gameoverScreen.SetActive( true );
		yield return new WaitForSeconds( minDurationOfGameoverScreen );
		while( !Input.anyKeyDown ) {
			yield return null;
		}
		Application.LoadLevel( Application.loadedLevel );
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}