using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static int currentTimeMinutes;
    public static int currentTimeHours;

    public static int investigationStopTimeMinutes;
    public static int investigationStopTimeHours;

    void Awake()
    {
        currentTimeHours = 13;
        currentTimeMinutes = 30;

        investigationStopTimeHours = 16;
        investigationStopTimeMinutes = 30;
    }

    public void AddTime(int timeAdded)
    {
        currentTimeMinutes = currentTimeMinutes + timeAdded;

        if (currentTimeMinutes > 60)
        {
            currentTimeHours = currentTimeHours + currentTimeMinutes / 60;
            currentTimeMinutes = currentTimeMinutes - 60 * (currentTimeMinutes / 60);

            if(currentTimeHours >= investigationStopTimeHours) { print("time is up (work in progress)"); }
        }
    }
}
