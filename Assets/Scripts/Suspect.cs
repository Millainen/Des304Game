using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public int minutesItTakesToInvestiGate;

    public string suspectName;
    public bool isMurderer;
    public bool hasBeenSuspected;
    public Color suspectedColor;
    public string[] thoughtsHad;

    void Start() {
        minutesItTakesToInvestiGate = Random.Range(10, 60);

        spriteRenderer = GetComponent<SpriteRenderer>();
        suspectedColor = new Color(0.5943396f, 0.2641596f, 0.09251513f, 1);
    }

    void Update()
    {
        if (hasBeenSuspected)
        {
            spriteRenderer.color = suspectedColor;
        }
    }
}
