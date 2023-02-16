using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Francis : NPC
{
    public override void Start() {
        base.Start();
        speakerName = "Francis";
        lines = new string[] {"Hi!", "This is a test dialog!"};
    }
}
