using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtManager : MonoBehaviour
{
    public GameObject canvas;
    ReadMindUI readMindUI;

    public static int thoughtsYouHaveRead;
    public static int maxThoughtsYouCanRead = 6;

    public GameObject thoughts;
    public AThought[] thoughtScriptRefs;

    public int[] whichThoughtsAreChosen;
    public int[] whichThoughtsAreShown;

    bool[] thoughtsReadAdded;

    private void Start()
    {
        readMindUI = canvas.GetComponent<ReadMindUI>();

        thoughtScriptRefs = thoughts.GetComponentsInChildren<AThought>();

        whichThoughtsAreChosen = new int[3];

        whichThoughtsAreChosen[0] = 0;
        whichThoughtsAreChosen[1] = 0;
        whichThoughtsAreChosen[2] = 0;

        whichThoughtsAreShown = new int[3]; //have the game remember this information throughout scene loads

        whichThoughtsAreShown[0] = 0;
        whichThoughtsAreShown[1] = 0;
        whichThoughtsAreShown[2] = 0;

        thoughtsReadAdded = new bool[3];
    }

    private void Update()
    {
        ChooChooChooseThoughts(); // call this from the thoughts instead!
        ShoShoShowThoughts();
    }

    void ChooChooChooseThoughts()
    {
        if (thoughtScriptRefs[0].isChosen)
        {
            whichThoughtsAreChosen[0] = 1;
            whichThoughtsAreChosen[1] = 0;
            whichThoughtsAreChosen[2] = 0;
        }
        else if (thoughtScriptRefs[0].isChosen == false)
            whichThoughtsAreChosen[0] = 0;

        if (thoughtScriptRefs[1].isChosen)
        {
            whichThoughtsAreChosen[0] = 0;
            whichThoughtsAreChosen[1] = 1;
            whichThoughtsAreChosen[2] = 0;
        }
        else if (thoughtScriptRefs[1].isChosen == false) 
            whichThoughtsAreChosen[1] = 0;

        if (thoughtScriptRefs[2].isChosen) 
        {
            whichThoughtsAreChosen[0] = 0;
            whichThoughtsAreChosen[1] = 0;
            whichThoughtsAreChosen[2] = 1;
        }
        else
            whichThoughtsAreChosen[2] = 0;
    }

    public void ShoShoShowThoughts()
    {
       // print("do we get here?");
        if (thoughtScriptRefs[0].isShown)
        {
            if(thoughtsReadAdded[0] == false)
            {
                thoughtsYouHaveRead = thoughtsYouHaveRead + 1;
                print(thoughtsYouHaveRead + " from thought 0");
                thoughtsReadAdded[0] = true;
            }
            whichThoughtsAreShown[0] = 1;
            readMindUI.UpdateTheThoughtsReadText();
        }
        if (thoughtScriptRefs[1].isShown)
        {
            if (thoughtsReadAdded[1] == false)
            {
                thoughtsYouHaveRead = thoughtsYouHaveRead + 1;
                print(thoughtsYouHaveRead + " from thought 1");
                thoughtsReadAdded[1] = true;
            }
            whichThoughtsAreShown[1] = 1;
            readMindUI.UpdateTheThoughtsReadText();
        }
        if (thoughtScriptRefs[2].isShown)
        {
            if (thoughtsReadAdded[2] == false)
            {
                thoughtsYouHaveRead = thoughtsYouHaveRead + 1;
                print(thoughtsYouHaveRead + " from thought 2");
                thoughtsReadAdded[2] = true;
            }
            whichThoughtsAreShown[2] = 1;
            readMindUI.UpdateTheThoughtsReadText();
        }
    }
}
