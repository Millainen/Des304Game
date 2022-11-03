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
    public TextMeshProUGUI thoughtsText;

    string theText;

    private void Start()
    {
        suspectText = GetComponentInChildren<TextMeshProUGUI>();
        suspectText.gameObject.SetActive(false);
    }
    void Update()
    {
        thoughtsText.text = ThoughtManager.thoughtsYouHaveRead + "/" + ThoughtManager.maxThoughtsYouCanRead + " thoughts read.";

        if (GamesManager.suspectUnderRadar)
        {
            DetermineTheText();
            suspectText.SetText(GamesManager.suspectName + theText);
            suspectText.gameObject.SetActive(true);
        }
        else
            suspectText.gameObject.SetActive(false);

        currentTimeText.text = "Time: " + TimeManager.currentTimeHours.ToString() + ":" + TimeManager.currentTimeMinutes.ToString();
        investigationStopTimeText.text = "Investigation stops at " + TimeManager.investigationStopTimeHours.ToString() + ":" + TimeManager.investigationStopTimeMinutes.ToString();
    }

    void DetermineTheText()
    {
        switch (GamesManager.suspectName)
        {
            case "John Smith":
                if (GamesManager.suspectsInvestigated[0] == false)
                    theText = ". \nIt will take " + GamesManager.susCode[0].minutesItTakesToInvestiGate.ToString() + " minutes to investigate him.";
                else
                    theText = ". \nYou have already investigated him.";
                break;
            case "Karen Maren":
                if (GamesManager.suspectsInvestigated[1] == false)
                    theText = ". \nIt will take " + GamesManager.susCode[1].minutesItTakesToInvestiGate.ToString() + " minutes to investigate her.";
                else
                    theText = ". \nYou have already investigated her.";
                break;
            case "Katja Kuusi":
                if (GamesManager.suspectsInvestigated[2] == false)
                    theText = ". \nIt will take " + GamesManager.susCode[2].minutesItTakesToInvestiGate.ToString() + " minutes to investigate her.";
                else
                    theText = ". \nYou have already investigated her.";
                break;
        }

    }
}
