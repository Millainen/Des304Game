using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addtimetest : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI maxTimeText;

    public int currentTimeMinutes;
    public int currentTimeHours;

    int maxTimeMinutes;
    int maxTimeHours;

    public int addedTime;
    void Start()
    {
        currentTimeHours = 10;
        currentTimeMinutes = 30;

        maxTimeHours = 16;
        maxTimeMinutes = 30;

        currentTimeText.text = "Time: " + currentTimeHours.ToString() + ":" + currentTimeMinutes.ToString();
        maxTimeText.text = "Investigation stops at " + maxTimeHours.ToString() + ":" + maxTimeMinutes.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            addedTime = Random.Range(20,60);
            UpdateTime(addedTime);
        }
    }

    void UpdateTime(int addedTimeInMinutes)
    {
        currentTimeMinutes = currentTimeMinutes + addedTimeInMinutes;

        if (currentTimeMinutes > 60)
        {
            currentTimeHours = currentTimeHours + currentTimeMinutes / 60;
            currentTimeMinutes = currentTimeMinutes - 60 * (currentTimeMinutes / 60);

            if (currentTimeHours >= maxTimeHours && currentTimeMinutes >= maxTimeMinutes)
            {
                print("time is up");
            }
        }

        if (currentTimeMinutes < 10)
            currentTimeText.text = "Time: " + currentTimeHours.ToString() + ":0" + currentTimeMinutes.ToString();
        else
            currentTimeText.text = "Time: " + currentTimeHours.ToString() + ":" + currentTimeMinutes.ToString();
    }
}
