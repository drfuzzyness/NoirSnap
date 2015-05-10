﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof (Tonemapping) )]
[RequireComponent(typeof (VignetteAndChromaticAberration) )]
[RequireComponent(typeof (NoiseAndGrain))]
public class PlayerUIManager : MonoBehaviour {
	
	[Header("Camera Effects")]
	public bool noiseAndGrainEnabled;
	private NoiseAndGrain noiseAndGrain;
	
	[Header("Camera Flash Effect")]
	public bool isFlashing;
	public float flashDuration;
	public float flashExposurePeak; // lel exposure
	public AnimationCurve flashTransition; // runs the curve backwards so it's easy to use the templates
	public static PlayerUIManager instance;
	private Tonemapping tonemapping;
	
	[Header("Stealth Effect")]
	public bool inStealth = true;
	public float brokenStealthVignette;
	public AnimationCurve stealthTransition;
	public float stealthBrokenTime;
	public float stealthGainTime;
	
	
	private VignetteAndChromaticAberration vignette;	

	public void CueCameraFlash() {
		StartCoroutine( CameraFlash() );
	}
	
	IEnumerator CameraFlash() {
		if( isFlashing ) {
			Debug.LogWarning( "Already Flashing" );
			yield break;
		}
		isFlashing = true;
		float prevExposure = tonemapping.exposureAdjustment;
		float ratio = 1f;
		Application.CaptureScreenshot( Time.time.ToString() + Time.unscaledTime.ToString() + ".png" );
		yield return null;
		for( float timer = flashDuration; timer > 0f; timer -= Time.deltaTime) {
// 			Debug.Log( "flashing " + timer );
			ratio = timer / flashDuration;
// 			Debug.Log( Mathf.Lerp( prevExposure, flashExposurePeak, flashTransition.Evaluate( ratio ) ) );
			tonemapping.exposureAdjustment = Mathf.Lerp( prevExposure, flashExposurePeak, flashTransition.Evaluate( ratio ) );
			yield return null;
		}
		tonemapping.exposureAdjustment = prevExposure;
		isFlashing = false;
	}
	
	public void SeenByEnemy() {
		if( inStealth) {
			StartCoroutine( BreakStealth() );
			inStealth = true;
		}
	}
	
	public void NoLongerSeen() {
		if( !inStealth) {
			StartCoroutine( GainStealth() );
			inStealth = false;
		}
	}
	
	IEnumerator BreakStealth() {
		float previousVignette = vignette.intensity;
		for( float timer = 0f; timer < stealthBrokenTime; timer += Time.deltaTime ) {
			yield return null;
		}
	}
	
	IEnumerator GainStealth() {
		yield return null;
	}

	void Awake() {
		instance = this;
	}	

	void Start () {
		tonemapping = GetComponent<Tonemapping>();
		vignette = GetComponent<VignetteAndChromaticAberration>();
		noiseAndGrain = GetComponent<NoiseAndGrain>();
		inStealth = true;	
	}
	
	
	// Update is called once per frame
	void Update () {
		Debug.Log( vignette.intensity );
		if( noiseAndGrainEnabled ) {
			noiseAndGrain.enabled = true;
		} else {
			noiseAndGrain.enabled = false;
		}
		
	}
}
