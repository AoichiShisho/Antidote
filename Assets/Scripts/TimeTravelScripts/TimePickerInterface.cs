using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePickerInterface : IUIElement<TimePickerInterface>
{
    public Text PeriodDisplay;
    public Button prev, next;

    public override void Awake()
    {
        Instance = this;
        UIElement = GameObject.Find("TimePicker");
        prev.onClick.AddListener(UpdateText);
        next.onClick.AddListener(UpdateText);
    }

    public void UpdateText()
    {
        PeriodDisplay.text = TimeTravelController.Instance.GetCurrentPeriod().ToString();
    }
}