using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCTalkBase : MonoBehaviour
{
    public string npcName;
    public string[] npcDialog;
    public int currentLine;

    public GameObject canvas;
    public GameObject dialogueSign;
    public GameObject speechBubble;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public bool isPlayerInContact = false;


    void Start()
    {
        currentLine = 0;
    }

    void Update()
    {
        if (isPlayerInContact && dialogueSign.activeSelf && Input.GetKeyDown(KeyCode.Return)) {
            if (currentLine < npcDialog.Length) {
                ShowDialogue();
                nameText.text = npcName;
                dialogueText.text = npcDialog[currentLine];
                currentLine++;
            } else {
                HideDialogue();
                currentLine = 0;
            }
        }
    }

    protected virtual void OnCollisionStay(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerInContact = true;
        }
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerInContact = false;
        }
    }

    public void FindDialogue()
    {
        canvas = GameObject.FindWithTag("Canvas");
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
        nameText = GameObject.Find("NameText").GetComponent<TMP_Text>();
        dialogueSign = GameObject.Find("DialogueSign");
        speechBubble = GameObject.Find("SpeechBubble");
    }

    public void ShowDialogue()
    {
        dialogueSign.SetActive(true);
        speechBubble.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        nameText.gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        dialogueSign.SetActive(false);
        speechBubble.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        nameText.gameObject.SetActive(false);
    }

}
