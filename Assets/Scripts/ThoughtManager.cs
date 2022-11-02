using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtManager : MonoBehaviour
{
    public GameObject thoughts;
    public AThought[] thoughtScriptRefs;

    public int[] whichThoughtsAreChosen;

    private void Start()
    {
        thoughtScriptRefs = thoughts.GetComponentsInChildren<AThought>();

        whichThoughtsAreChosen = new int[3];

        whichThoughtsAreChosen[0] = 0;
        whichThoughtsAreChosen[1] = 0;
        whichThoughtsAreChosen[2] = 0;
    }

    private void Update()
    {
        ChooChooChooseThoughts();
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
}
