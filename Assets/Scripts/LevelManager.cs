using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {


	public float minDurationOfGameoverScreen;
	public GameObject gameoverScreen;
	public GameObject playerVictoryScreen;
	
	[Header("Photography Display")]
	public GameObject photographPrefab;
	public Transform firstImageLoc;
	public Vector3 transformPerImage;
	public static LevelManager instance;
	private bool decisionMade;
	public int nextLevelIndex;
	public List<int> possibleNextScenes;	
	
	public void playerCaught( ) {
		if( !decisionMade ) {
			StartCoroutine( gameoverScene() );
			decisionMade = true;
		}
	}

	public void playerDied() {
		if( !decisionMade ) {
			StartCoroutine( gameoverScene() );
			decisionMade = true;
		}
	}

	public void playerWon() {
		if( !decisionMade ) {
			StartCoroutine( playerVictoryScene() );
			decisionMade = true;
		}
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
		playerVictoryScreen.SetActive( true );
		yield return StartCoroutine( displayPhotos() );
		yield return new WaitForSeconds( minDurationOfGameoverScreen );
		while( !Input.anyKeyDown ) {
			yield return null;
		}
		Application.LoadLevel( GetNextScene() );
	}
	
	IEnumerator displayPhotos() {
		foreach( Texture thisTexture in PhotographyManager.instance.screenshots ) {
// 			GUI.DrawTexture(new Rect(100,100,100,100), thisTexture, ScaleMode.ScaleToFit, true, 10.0f);
			Debug.Log( "trying to instantiate" );
			Transform thisImageTrans = Instantiate( photographPrefab.transform ) as Transform;
			Debug.Log( "trying to set parent" );
			thisImageTrans.SetParent( playerVictoryScreen.transform );
			Debug.Log("trying to set texture: " + thisTexture);
			thisImageTrans.GetComponent<RawImage>().texture = thisTexture as Texture;
			Debug.Log("texture set");
			thisImageTrans.localPosition = firstImageLoc.localPosition;
			thisImageTrans.localRotation = firstImageLoc.localRotation;
// 			Vector3 scale = thisImageTrans.localScale;
			firstImageLoc.Translate( transformPerImage, Space.Self );
// 			yield return null;
		}
		yield return null;
	}
	
	int GetNextScene() {
		int index = Random.Range( 0, possibleNextScenes.Count );
		 // Random.Range will never return the max value, so can use a value that's 1 greater than the index range
		return possibleNextScenes[ index ];
	}

	// Use this for initialization
	void Start () {
		if( possibleNextScenes.Count == 0 ) {
			Debug.LogError( "No next level has been set. Check the LevelManager." );
		}
		instance = this;
		decisionMade = false;
	}
}
