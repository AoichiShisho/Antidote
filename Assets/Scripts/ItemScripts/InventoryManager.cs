using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemProperties> Items = new List<ItemProperties>();

    private void Awake()
    {
        Instance = this;
    }

    public void Add(ItemProperties item)
    {
        Items.Add(item);
        InventoryBarController.Instance.UpdateItems();
    }

    public void Remove(ItemProperties item)
    {
        Items.Remove(item);
        InventoryBarController.Instance.UpdateItems();
    }
}
