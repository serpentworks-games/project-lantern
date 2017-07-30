/// <summary>
/// Pick Up Item:
/// 
/// Use to pick up an object based on the raycast event from World Interaction. Places object as child
/// of a 'hold object/hand' at its zero's position (currently) and then releases it with the Interact key
/// 
/// AUTHOR: A. BARTA
/// LAST UPDATE: May 16 2017 3 pm
/// 
/// NEEDED: addition of animation hash ID calls, potentially better function calls
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : InteractableObj {
	public GameObject interactObj; // raycasted object
	public bool holdingObject; // if we're holding an object
	public GameObject holdObject; // sets the raycasted object to a local variable
	Rigidbody rB; // holder for rigidbody of interactObj

    public override void Interact()
    {
		// Get references to interacted object and it's rigidbody
		interactObj = GameObject.FindWithTag ("Player").GetComponent<WorldInteraction> ().interactedObject;
		rB = interactObj.GetComponent<Rigidbody> ();
		holdObject = GameObject.Find ("HoldObject");

		// If E is pressed and no object is held...
		if (!holdingObject) {
			PickUp ();

		} // .... other wise....
		else if (holdObject) {
			PutDown ();
		}

    }

	void PickUp(){
		// This picks up the object and turns off physics
		rB.isKinematic = true;
		interactObj.transform.parent = holdObject.transform;
		interactObj.transform.localPosition = new Vector3 (0, 0, 0);
		interactObj.transform.localRotation = new Quaternion (0, 0, 0, 0);
		holdingObject = true;


	}
	void PutDown(){
		// This puts the object down and turns physics back on, so it falls to the floor
		interactObj.transform.parent = null;
		holdingObject = false;
		rB.isKinematic = false;

	}
		

}
