using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public GameObject canvas;
    TimeManager timeManagerScrpt;

    public static string suspectName;
    public static bool suspectUnderRadar;

    public GameObject suspects;
    public static Suspect[] susCode;

    public static bool[] suspectsInvestigated = new bool[3];

    public static Suspect suspect;

    public GameObject playerCharacter;
    public static Vector2 playerCharPositionRecord = new Vector2();

    bool[] timeAdded;

    void Start()
    {
        timeManagerScrpt = canvas.GetComponent<TimeManager>();

        susCode = suspects.GetComponentsInChildren<Suspect>();

        timeAdded = new bool[3];

        WhichSuspectsHaveBeenInvestigated();

        if (playerCharPositionRecord.x != 0)
        {
            playerCharacter.transform.position = playerCharPositionRecord;
        }
    }

    void WhichSuspectsHaveBeenInvestigated()
    {
        if (suspectsInvestigated[0] == true) susCode[0].hasBeenSuspected = true;
        if (suspectsInvestigated[1] == true) susCode[1].hasBeenSuspected = true;
        if (suspectsInvestigated[2] == true) susCode[2].hasBeenSuspected = true;
    }

    void Update()
    {
        if (suspectUnderRadar && Input.GetKeyDown(KeyCode.E) && !suspect.hasBeenSuspected) {
            switch (suspectName)
            {
                case "John Smith":
                    InvestigateWho(0);
                    break;
                case "Karen Maren":
                    InvestigateWho(1);
                    break;
                case "Katja Kuusi":
                    InvestigateWho(2);
                    break;
            }
            //suspect.hasBeenSuspected = true;
            playerCharPositionRecord = playerCharacter.transform.position;
            SceneManager.LoadScene("ReadMind");
            }
    }

    void InvestigateWho(int who)
    {
        if (!timeAdded[who])
        {
            timeManagerScrpt.AddTime(susCode[who].minutesItTakesToInvestiGate);
            timeAdded[who] = true;
        }
        suspectsInvestigated[who] = true;
    }
}
