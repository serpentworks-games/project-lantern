/// <summary>
/// World interaction:
/// 
/// Script that contains all the various interaction calls per different objects. Uses raycasting to 
/// find the object interacting with, within a small distance from the player, and then based on their
/// tags determines what script flow follows. 
/// 
/// This takes the place of trigger volumes for pick up objects, NPCs, and actionable objects.
/// 
/// AUTHOR: A. BARTA
/// LAST UPDATED: May 16, 2017 3 pm
/// 
/// NEEDED: Reset tag for pick up objects, which are different from actionable objects
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {

	public float rayRange; // How far away do you want the player from the object before interacting?
	public float rayHeight; // Height from the ground plane the ray casts from
	public GameObject interactedObject; // Object the ray hits
 	int layerMask; // Layer the object is on | WILL ALWAYS BE INTERACT
	GameObject player; // Reference to the player

	RaycastHit interactInfo; 
	Ray interactRay;

	// Instance these variables first
	void Awake(){
		layerMask = LayerMask.GetMask ("Interact");
		player = GameObject.FindWithTag ("Player");
		interactRay = new Ray ();
	}


	void Update () {
        if(Input.GetButtonDown("Interact"))
			GetInteraction ();		
	}

	// Raycast event called every frame to interact with the world.
	void GetInteraction(){

		//Sets the origin and direction of the ray
		interactRay.origin = player.transform.position  + transform.up * rayHeight;
		interactRay.direction = player.transform.forward;

		if (Physics.Raycast (interactRay, out interactInfo, rayRange, layerMask)) {
			Debug.DrawRay (interactRay.origin, interactRay.direction * rayRange, Color.green, 1, false);
			interactedObject = interactInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable") {
				// For objects tagged: Interactable

				interactedObject.GetComponent<InteractableObj> ().Interact ();

			} else if (interactedObject.tag == "NPC") {
				// For objects tagged: NPC
				interactedObject.GetComponent<InteractableObj> ().npcInteract ();
            }
            else if (interactedObject.tag == "Action Object")
            {
                // For objects tagged: Action Object
                // ie switches
                interactedObject.GetComponent<InteractableObj>().actionInteract();

            }
            else {
				
				// Used for debugging
				Debug.Log ("No Interactable found");
			}


		
		} else { 

			//Used for debugging
			Debug.Log ("No raycast event");
		}
	}

}
