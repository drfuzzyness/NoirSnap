using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Dialogue : MonoBehaviour {

	[Header("Dialogue")]
	public List<string> lines;
	public List<float> delays;

	[Header("Setup")]
	public bool resetOnCompletion;
	public Text outputStream;
	public List<GameObject> informOnCompletion;

	private int playhead = 0;
	private string startingOutput;
	private bool paused;

	// Use this for initialization
	void Start () {
		startingOutput = outputStream.text;
		playhead = 0;
		validate();
	}

	public void play() {
		if( playhead == 0 ) {
			StartCoroutine( playbackRoutine() );
		} else if( paused ) {
			paused = false;
		} else {
			Debug.LogWarning( "Dialogue is already playing" );
		}
	}

	public void pause() {
		if( playhead == 0 ) {
			paused = true;
		} else if( paused ) {
			Debug.LogWarning( "Dialogue is already paused" );
		}
	}

	public bool isPlaying() {
		return paused;
	}

	public void reset() {
		playhead = 0;
		outputStream.text = startingOutput;
	}

	IEnumerator playbackRoutine() {
		validate();
		while( playhead < lines.Count ) {
			outputStream.text += "\n" + lines[ playhead ];
			yield return new WaitForSeconds( delays[ playhead ] );
			while( paused ) {
				yield return null;
			}
			playhead++;
		}
		foreach( GameObject thisObj in informOnCompletion ) {
			thisObj.SendMessage( "OnDialogueCompleted" );
		}
		if( resetOnCompletion ) {
			reset();
		}
	}

	private void validate() {
		if( lines.Count != delays.Count ) {
			Debug.LogError( "There are an unequal number of lines and delays" );
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
