using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDialogue : IInteractable {
    public string speakerName;
    public string[] lines;
    private int currentLine;

    public virtual void Start()
    {
        currentLine = 0;
    }

    public override void DoInteraction()
    {
        base.DoInteraction();
        if (currentLine < lines.Length)
        {
            DialogBox.Instance.Show();
            DialogBox.Instance.SetDialogBox(speakerName, lines[currentLine++]);
        } else {
            StopInteraction();
        }
    }

    public override void StopInteraction()
    {
        DialogBox.Instance.Hide();
        currentLine = 0;
    }
}