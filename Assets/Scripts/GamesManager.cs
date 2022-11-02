using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static string suspectName;
    public static bool suspectUnderRadar;

    public GameObject suspects;
    public Suspect[] susCode;

    public static bool[] suspectsInvestigated = new bool[3];

    public static Suspect suspect;

    public GameObject playerCharacter;
    public static Vector2 playerCharPositionRecord = new Vector2();


    void Start()
    {
        susCode = suspects.GetComponentsInChildren<Suspect>();

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
                    suspectsInvestigated[0] = true;
                    break;
                case "Karen Maren":
                    suspectsInvestigated[1] = true;
                    break;
                case "Katja Kuusi":
                    suspectsInvestigated[2] = true;
                    break;
            }
            //suspect.hasBeenSuspected = true;
            playerCharPositionRecord = playerCharacter.transform.position;
            SceneManager.LoadScene("ReadMind");
            }
    }
}
