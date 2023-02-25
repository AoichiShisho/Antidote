using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainer : IHover
{
    public ItemProperties item;

    public override void DoHoverAction()
    {
        Tooltip.Instance.DisplayTooltip(item.itemName, item.desc);
        Tooltip.Instance.Show();
    }

    public override void StopHoverAction()
    {
        Tooltip.Instance.Hide();
    }
}
