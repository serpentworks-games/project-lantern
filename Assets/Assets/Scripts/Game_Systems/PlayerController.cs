using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// REMEMBER TO IMPLIMENT ACTUAL MOVEMENT CODE AT THE BOTTOM
	public float speed = 10f;
	public float turnSmooth = 0.6f;
	public bool isGrounded;
	Rigidbody playerRB;

	void Awake(){
		playerRB = GetComponent<Rigidbody> ();
	}
	void FixedUpdate(){
		float mH = Input.GetAxisRaw ("Horizontal");
		float mV = Input.GetAxisRaw ("Vertical");
		Movement (mH, mV);
	//	Turning (mH, mV);
	}

	void Movement(float mH, float mV){
		Vector3 movement = new Vector3 (mH, 0.0f, mV);
		movement = movement.normalized * speed * Time.deltaTime;
		movement.y = 0.0f;
		playerRB.MovePosition (transform.position + movement);

		Quaternion newRot = Quaternion.LookRotation (movement);
		if (mH != 0 || mV != 0) {
			if (movement != Vector3.zero) {
				playerRB.MoveRotation(Quaternion.Lerp (transform.rotation, newRot, turnSmooth * Time.deltaTime));
			} else {
				Debug.Log ("Movement v3 is " + movement);
			}
		} else {
			Debug.Log ("mH = " + mH + " | mV = " + mV);
		}
		Debug.Log ("mH = " + mH + " | mV = " + mV);
	}
	void Turning(float mH, float mV){

		playerRB.rotation = Quaternion.LookRotation (new Vector3 (mH, 0, mV));
		/*if (mH != 0 || mV != 0) {
			var newRotation = Quaternion.LookRotation (new Vector3 (mH, 0, mV));
			var curRotation = playerRB.rotation;
			if (curRotation != newRotation) {
				
				playerRB.rotation = Quaternion.Slerp (curRotation, newRotation, turnSmooth * Time.deltaTime);
			}
		}*/
	}
}
