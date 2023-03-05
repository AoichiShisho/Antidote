using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleWatcher : MonoBehaviour
{
    public Puzzle watch;

    public void OnSolve()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (watch.IsSolved()) OnSolve();
    }
}