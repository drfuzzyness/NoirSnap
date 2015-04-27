using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Rigidbody))]
public class Mob : MonoBehaviour {

	public bool walkOnStart;

	[Header("State")]
	private float currentSpeed;
	public bool isWalking;
	public bool isRunning;

	[Header("Balance")]
	public float walkSpeed;
	public float runSpeed;
	public float stoppedDrag;

	private NavMeshAgent agent;

	public void turnToFace( Transform target ) {
		// clamps Z and X and looks at target transform
		Vector3 prevRot = transform.eulerAngles;
		transform.LookAt( target );
		Vector3 newRot = transform.eulerAngles;
		newRot.x = prevRot.x;
		newRot.z = prevRot.z;
		transform.eulerAngles = newRot;

	}

	public void setDestination( Vector3 target ) {
//		agent.SetDestination( target );
	}

	public void walk() {
//		agent.speed = runSpeed;
//		agent.Resume();
		isWalking = true;
		isRunning = false;
		GetComponent<Rigidbody>().drag = .01f;
		currentSpeed = walkSpeed;

	}

	public void run() {
//		agent.speed = runSpeed;
//		agent.Resume();
		isWalking = false;
		isRunning = true;
		GetComponent<Rigidbody>().drag = .01f;
		currentSpeed = runSpeed;
	}

	public void stop() {
//		agent.Stop();
		isWalking = false;
		isRunning = false;
		currentSpeed = 0f;
		GetComponent<Rigidbody>().drag = stoppedDrag;
	}

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		stop();
		if( walkOnStart ) {
			walk();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		// move forward if walking or running and is moving slower than maxspeed
		if( ( isWalking || isRunning ) && GetComponent<Rigidbody>().velocity.magnitude < currentSpeed ) {
			GetComponent<Rigidbody>().AddForce( transform.forward * currentSpeed / 4, ForceMode.VelocityChange );
		}
	}
}
