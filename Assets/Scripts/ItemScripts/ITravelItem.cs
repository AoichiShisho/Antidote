using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ITravelItem : Item 
{
    public abstract void SetTimePeriod(TimePeriod newPeriod);
}