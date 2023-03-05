using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePickerInterface : IHover
{
    public Text PeriodDisplay;
    public Button prev, next;
    private bool isOpen = false;
    static float t = 1.0f;
    static readonly float TRANSITION_SPEED = 10f;
    static float StartingX;

    public void Awake()
    {
        prev.onClick.AddListener(UpdateIndicator);
        next.onClick.AddListener(UpdateIndicator);
        StartingX = transform.position.x;
    }

    public override void Update()
    {
        base.Update();
        transform.position = new Vector3(Mathf.Lerp(StartingX - 80, StartingX, t), transform.position.y, transform.position.z);
        t += TRANSITION_SPEED * Time.deltaTime * (isOpen ? -1 : 1);
        t = Mathf.Min(t, 1);
        t = Mathf.Max(t, 0);
    }

    public override void DoHoverAction()
    {
        isOpen = true;
    }

    public override void StopHoverAction()
    {
        isOpen = false;
    }

    public void UpdateIndicator()
    {
        int period = (int) TimeTravelController.Instance.GetCurrentPeriod();
        GameObject indicators = GameObject.Find("TimeIndicators");
        int i = 0;
        foreach (Transform indicator in indicators.transform) {
            if (i++ == period) {
                indicator.gameObject.GetComponent<Image>().color = Color.red;
            } else {
                indicator.gameObject.GetComponent<Image>().color = Color.white;
            }
        }
    }
}