using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance { get; set; }

    public string npcName;
    public GameObject dialoguePanel;

    public List<string> dialogueLines = new List<string>();
    Button nextButton;
    Text dialogueText, nameText;
    int dialogueIndex;



    // Use this for initialization
    void Awake () {
        nextButton = dialoguePanel.transform.FindChild("NextButton").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("DialogueBox").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("NPC_Name").GetChild(0).GetComponent<Text>();
        nextButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;

        Debug.Log(dialogueLines.Count);
       
       
            CreateDialogue();
     
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);

    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

}
