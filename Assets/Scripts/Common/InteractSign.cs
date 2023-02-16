using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractSign : IUIElement<InteractSign>
{
    public override void Awake()
    {
        Instance = this;
        UIElement = GameObject.Find("InteractSign");
    }
}