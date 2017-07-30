/// <summary>
/// Interactable Object:
/// 
/// Base class to extend interactability for objects, but not NPCs
/// 
/// AUTHOR: A. BARTA
/// LAST UPDATED: May 16, 2017 3 pm
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour {

	public virtual void Interact(){

			Debug.Log ("Interacting with base class!");
	}

    public virtual void npcInteract()
    {

    }

    public virtual void actionInteract()
    {

    }
}
