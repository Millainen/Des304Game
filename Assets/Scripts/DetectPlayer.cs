using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameObject magnifyingGlass;
    [HideInInspector]
    public Suspect suspect;

    void Start()
    {
        magnifyingGlass.gameObject.SetActive(false);
        suspect = GetComponent<Suspect>();
    }

    //don't have separate update function just for this?
    void Update()
    {
        if (suspect.hasBeenSuspected)
        {
            magnifyingGlass.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!suspect.hasBeenSuspected)
            {
                magnifyingGlass.gameObject.SetActive(true);
            }
            GamesManager.suspect = suspect;
            GamesManager.suspectUnderRadar = true;
            GamesManager.suspectName = this.name;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            magnifyingGlass.gameObject.SetActive(false);
            GamesManager.suspectUnderRadar = false;
        }
    }
}
