using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IUIElement<T> : MonoBehaviour
{
    public static T Instance;
    protected GameObject UIElement;
    public abstract void Awake();

    public void Start()
    {
       Hide();
    }

    public void Show()
    {
        UIElement.SetActive(true);
    }
    
    public void Hide()
    {
        UIElement.SetActive(false);
    }

    public bool IsVisible()
    {
        return UIElement.activeSelf;
    }
}