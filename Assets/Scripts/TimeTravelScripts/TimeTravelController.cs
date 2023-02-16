using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimePeriod {
	SEVEN_YRS_AGO,
	FIVE_YRS_AGO,
	TWO_YRS_AGO,
	ONE_DAY_AGO,
	INTRO
}

public class TimeTravelController : MonoBehaviour
{
	public static TimeTravelController Instance;
	private TimePeriod currentTime { get; set; }

	public TimePeriod GetCurrentPeriod()
	{
		return currentTime;
	}

	public void Awake()
	{
		Instance = this;
		currentTime = TimePeriod.INTRO;
	}

	private void broadcastTime()
	{
		GameObject[] travellers;
		travellers = GameObject.FindGameObjectsWithTag("TimeTravels");
		foreach (GameObject traveler in travellers)
		{
			traveler.SendMessage("SetTimePeriod", currentTime, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void goForward()
	{
		currentTime = (TimePeriod) Mathf.Min((int) currentTime + 1, (int) TimePeriod.ONE_DAY_AGO);
		broadcastTime();
	}

	public void goBackwards()
	{
		currentTime = (TimePeriod) Mathf.Max((int) currentTime - 1, (int) TimePeriod.SEVEN_YRS_AGO);
		broadcastTime();
	}

	public bool hasNext()
	{
		return currentTime != TimePeriod.ONE_DAY_AGO || currentTime != TimePeriod.INTRO;
	}

	public bool hasPrev()
	{
		return currentTime != TimePeriod.SEVEN_YRS_AGO;
	}
}