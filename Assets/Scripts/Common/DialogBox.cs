using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : IUIElement<DialogBox>
{
    private TMP_Text nameText;
    private TMP_Text speechText;

    public override void Awake()
    {
        Instance = this;
        UIElement = GameObject.Find("SpeechBubble");
        nameText = GameObject.Find("NameText").GetComponent<TMP_Text>();
        speechText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
    }

    public void SetDialogBox(string name, string speech)
    {
        nameText.text = name;
        speechText.text = speech;
    }
}