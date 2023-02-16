using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    private class Dialog
    {
        private string[] dialogLines;

        public IEnumerable next() {
            foreach (string line in dialogLines) {
                yield return line;
            }
        }
    }

    private Dialog dialog;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
