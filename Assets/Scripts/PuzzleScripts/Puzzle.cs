using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : IUIElement<Puzzle>
{
    private bool isSolved = false;

    public bool IsSolved()
    {
        return isSolved;
    }

    // attach this as a callback to the solving action
    public void Solve()
    {
        Destroy(gameObject);
        isSolved = true;
    }

    public override void Awake()
    {
        Instance = this;
        UIElement = gameObject;
    }
}
