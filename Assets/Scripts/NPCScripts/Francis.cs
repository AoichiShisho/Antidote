using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Francis : NPCTalkBase
{
    void Start() {
        npcName = "Francis";
        npcDialog = new string[] {"Hi!", "This is a test dialog!"};
        FindDialogue();
        HideDialogue();
    }
}
