using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAllow : MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 targetPosition;
    private float duration;

    private float time;
    //private int _dirFactor = 1;
    private bool inverse = false;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        duration = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= duration)
        {
            time = 0;
            inverse = !inverse;
        }

        if (inverse)
        {
            rect.localPosition += new Vector3(0, Time.deltaTime * 17, 0);
        }
        else
        {
            rect.localPosition -= new Vector3(0, Time.deltaTime * 17, 0); ;
        }
    }
}