/// <summary>
/// Simple call function for NPC dialogue behaviours. Allows the passing of custom dialogue and name
/// strings in the inspector.
/// 
/// AUTHOR: A. BARTA
/// LAST UPDATED: May 16 2017 3 pm
/// 
/// NEEDED: Reference to JSON file for dialogue trees and NPC names
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObj {
    public string[] dialogue;
    public string name;

	public override void npcInteract()
    {
        // if you interact with this NPC, instance the UI and print text to the screen with NPC name
 	       DialogueManager.Instance.AddNewDialogue(dialogue, name);
 
    }

}
