using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem Instance { get; set; }
    public List<string> dialogueScripts = new List<string>();
    public string npcName;
    public GameObject dialoguePanel;
    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] scripts, string npcName)
    {
        dialogueIndex = 0;
        dialogueScripts = new List<string>(scripts.Length);
        dialogueScripts.AddRange(scripts);
        this.npcName = npcName;

        Debug.Log(dialogueScripts.Count);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueScripts[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueScripts.Count -1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueScripts[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

}//End DialogueSystem Class
