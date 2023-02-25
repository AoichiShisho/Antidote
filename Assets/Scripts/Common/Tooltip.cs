using System;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : IUIElement<Tooltip>
{
    private DateTime mouseEnter;
    private static readonly TimeSpan DISPLAY_THRESHOLD = TimeSpan.FromMilliseconds(100);
    public GameObject ItemTitle, ItemDesc;

    public override void Awake()
    {
        UIElement = GameObject.Find("TooltipBackground");
        Instance = this;
    }

    public void DisplayTooltip(string name, string desc)
    {
        ItemTitle.GetComponent<Text>().text = name;
        ItemDesc.GetComponent<Text>().text = desc;
        Rect tooltipBoundary = gameObject.GetComponent<RectTransform>().rect;
        gameObject.transform.position = new Vector3(Input.mousePosition.x + tooltipBoundary.width / 4, Input.mousePosition.y + tooltipBoundary.height / 4, 0);
    }
}
