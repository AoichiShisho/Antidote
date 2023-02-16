using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemProperties> Items = new List<ItemProperties>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private bool isPanelOpen()
    {
        return GameObject.Find("Inventory") != null;
    }

    private void CreateItem(ItemProperties item)
    {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Add(ItemProperties item)
    {
        Items.Add(item);
        if (isPanelOpen())
        {
            CreateItem(item);
        }
    }

    public void Remove(ItemProperties item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        // cleans content of inventory before displaying
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            CreateItem(item);
        }
    }
}
