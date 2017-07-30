using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour {
	public bool objectFound;
	public GameObject oClosest;
	public int itemsHeld;
	public bool holdingObject;
	public float delay = 2f;
	public bool count;

	public void Update (){
			if (holdingObject == false) {
				FindObject ();
			}
			if (count == true) {
				delay -= Time.deltaTime;
				if (delay == 0) {
					objectFound = true;
					count = false;
				} else if (delay < 0) {
					delay = 0f;
					count = false;
				} else {
					// do nothing
				}
				
			}

			PickUp ();

	}
	void OnTriggerStay(Collider pU){
		if (oClosest != null) {
			pU = oClosest.GetComponent<Collider> ();
			if (pU) {
				objectFound = true;
			} else {
				print ("Nothing here");
			}
		}
	}

	void OnTriggerExit(){
		objectFound = false;
	}

	void PickUp(){
		if (oClosest != null) {
			Collider co = oClosest.gameObject.GetComponent<Collider> ();
			Rigidbody rB = oClosest.gameObject.GetComponent<Rigidbody> ();
			if (Input.GetButtonDown ("Interact")) {
				if (objectFound && holdingObject == false) {
					print ("This is a Crate");
					co.enabled = false;
					rB.isKinematic = true;

					oClosest.transform.parent = GameObject.Find ("HoldObject").transform;
					oClosest.transform.localPosition = new Vector3 (0, 0, 0);
					oClosest.transform.localRotation = new Quaternion (0, 0, 0, 0);

					itemsHeld = 1;
					objectFound = false;
					delay = 2f;
					holdingObject = true;

				} else if (holdingObject) {
					oClosest.transform.parent = null;
					co.enabled = true;
					rB.isKinematic = false;
					print ("object put down");
					count = true;
					itemsHeld = 0;
					holdingObject = false;

				} else if (objectFound && holdingObject) {
					print ("you're already holding an object!");
					oClosest = null;
				}

			}
		} else {
			// do nothing
		}
	}
	void FindObject(){
		GameObject[] pickUps;
		pickUps = GameObject.FindGameObjectsWithTag ("Interactable");
		GameObject closest = null;
		float distance = 100.0f;
		Vector3 position = transform.position;
		foreach (GameObject go in pickUps) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		oClosest = closest;
	}
}
