using UnityEngine;
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
	private float previousVignette;
	
	
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
// 		Debug.Log("seenbyenemy playerUI");
		if( inStealth) {
			StartCoroutine( BreakStealth() );
			inStealth = false;
		}
	}
	
	public void NoLongerSeen() {
		if( !inStealth) {
// 			Debug.Log( "starting GainStealth coroutine");
			StartCoroutine( GainStealth() );
			inStealth = true;
		}
	}
	
	IEnumerator BreakStealth() {
		// plays the curve backwards
// 		Debug.Log("breaking stealth");
		float previousVignette = vignette.intensity;
		for( float timer = 0f; timer < stealthBrokenTime; timer += Time.deltaTime ) {
			float ratio = (stealthBrokenTime - timer)/stealthBrokenTime;
			vignette.intensity = Mathf.Lerp( brokenStealthVignette, previousVignette, stealthTransition.Evaluate(ratio) );
			yield return null;
		}
		vignette.intensity = brokenStealthVignette;
	}
	
	IEnumerator GainStealth() {
// 		float previousVignette = vignette.intensity;
		for( float timer = 0f; timer < stealthGainTime; timer += Time.deltaTime ) {
			float ratio = timer/stealthBrokenTime;
			Debug.Log( Mathf.Lerp( brokenStealthVignette, previousVignette, stealthTransition.Evaluate(ratio) ) );
			vignette.intensity = Mathf.Lerp( brokenStealthVignette, previousVignette, stealthTransition.Evaluate(ratio) );
			yield return null;
		}
		vignette.intensity = previousVignette;
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
// 		Debug.Log( vignette.intensity );
		if( noiseAndGrainEnabled ) {
			noiseAndGrain.enabled = true;
		} else {
			noiseAndGrain.enabled = false;
		}
		
	}
}
