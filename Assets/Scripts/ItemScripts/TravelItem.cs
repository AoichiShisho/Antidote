using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TravelItem : ITravelItem
{
    public TimePeriod CurrentPeriod;
    public List<Item> AlternateRepresenations;

    public void Start()
    {
        SetTimePeriod(CurrentPeriod);
    }

    public override void SetTimePeriod(TimePeriod newPeriod)
    {
        AlternateRepresenations[(int) CurrentPeriod].gameObject.SetActive(false);
        AlternateRepresenations[(int) newPeriod].gameObject.SetActive(true);
        item = AlternateRepresenations[(int) newPeriod].gameObject.GetComponent<Item>().item;
        CurrentPeriod = newPeriod;
    }

    public override void DoInteraction()
    {
        InventoryManager.Instance.Add(item);
        while (transform.childCount > 0) DestroyImmediate(transform.GetChild(0).gameObject);
        Destroy(gameObject);
    }

    public void OnDrawGizmosSelected()
    {
        foreach (TimePeriod period in TimePeriod.GetValues(typeof(TimePeriod)))
        {
            GameObject item = AlternateRepresenations[(int) period].gameObject;
            Gizmos.color = Color.Lerp(Color.red, Color.green, (int) period / (float) (int) TimePeriod.INTRO);
            Gizmos.DrawSphere(item.transform.position, .1f);
        }
    }
}

[CustomEditor(typeof(TravelItem))]
public class TravelItemEditor : Editor
{
    void OnSceneGUI()
    {
        TravelItem obj = (TravelItem) target;
        int index = 0;
        foreach (Transform child in obj.transform)
        {
            Item childObj = child.gameObject.GetComponent<Item>();
            if (index++ == (int) obj.CurrentPeriod) 
            {
                child.gameObject.SetActive(true);
            } else {
                child.gameObject.SetActive(false);
            }
            if (!obj.AlternateRepresenations.Contains(childObj)) obj.AlternateRepresenations.Add(childObj);
        }
        Item newItem = obj.AlternateRepresenations[(int) obj.CurrentPeriod];
        obj.item = newItem.item;
    }
}