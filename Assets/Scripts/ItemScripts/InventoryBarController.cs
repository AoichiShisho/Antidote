using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarController : MonoBehaviour
{
    public Button backpackButton;
    public GameObject inventoryBar;
    public GameObject itemContainer;
    private bool isOpen = true; 
    private static float TRANSITION_SPEED = 10f;
    public static InventoryBarController Instance;
    public static readonly Vector3 FIRST_ITEM_OFFSET = new Vector3(0, 0, 0);
    public static readonly Vector3 EACH_ITEM_OFFSET = new Vector3(45, 0, 0);

    static float t = 1.0f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        backpackButton.onClick.AddListener(ToggleState);
    }

    void Update()
    {
        Transform transform = inventoryBar.transform;
        transform.localScale = new Vector3(Mathf.Lerp(0, 1, t), 1, 1);

        t += TRANSITION_SPEED * Time.deltaTime * (isOpen ? 1 : -1);
        t = Mathf.Min(t, 1);
        t = Mathf.Max(t, 0);
    }

    public void ToggleState()
    {
        isOpen = !isOpen;
    }

    public void UpdateItems()
    {
        List<ItemProperties> items = InventoryManager.Instance.Items;

        // Destroy items before refresh
        foreach (Transform child in inventoryBar.transform)
        {
            Destroy(child.gameObject);
        }

        int i = 0;        
        foreach (ItemProperties item in items)
        {
            GameObject container = Instantiate(itemContainer, inventoryBar.transform);
            container.GetComponent<ItemContainer>().item = item;
            container.transform.Translate(FIRST_ITEM_OFFSET + i++ * EACH_ITEM_OFFSET);
            Image renderer = container.GetComponent<Image>();
            renderer.sprite = item.icon;
        }
    } 
}
