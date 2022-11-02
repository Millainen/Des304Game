using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI suspectText;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI investigationStopTimeText;

    string theText;

    public int[] timeInMinutes = new int[3];

    private void Start()
    {
        suspectText = GetComponentInChildren<TextMeshProUGUI>();
        suspectText.gameObject.SetActive(false);
        CalculateRandomTimes();
    }
    void Update()
    {
        if (GamesManager.suspectUnderRadar)
        {
            DetermineTheText();
            suspectText.SetText(GamesManager.suspectName + theText);
            suspectText.gameObject.SetActive(true);
        }
        else
            suspectText.gameObject.SetActive(false);
    }

    void CalculateRandomTimes()
    {
        if (timeInMinutes[0] == 0) timeInMinutes[0] = Random.Range(10, 60);
        if (timeInMinutes[1] == 0) timeInMinutes[1] = Random.Range(9, 65);
        if (timeInMinutes[2] == 0) timeInMinutes[2] = Random.Range(20, 40);
    }

    void DetermineTheText()
    {
        switch (GamesManager.suspectName)
        {
            case "John Smith":
                if (GamesManager.suspectsInvestigated[0] == false)
                    theText = ". \nIt will take " + timeInMinutes[0].ToString() + " minutes to investigate him.";
                else
                    theText = ". \nYou have already investigated him.";
                break;
            case "Karen Maren":
                if (GamesManager.suspectsInvestigated[1] == false)
                    theText = ". \nIt will take " + timeInMinutes[1].ToString() + " minutes to investigate her.";
                else
                    theText = ". \nYou have already investigated her.";
                break;
            case "Katja Kuusi":
                if (GamesManager.suspectsInvestigated[2] == false)
                    theText = ". \nIt will take " + timeInMinutes[2].ToString() + " minutes to investigate her.";
                else
                    theText = ". \nYou have already investigated her.";
                break;
        }

    }
}
