using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AThought : MonoBehaviour
{
    public GameObject canvas;
    ReadMindUI readMindUI;

    public string thoughtName;
    public bool isChosen;
    public bool isShown;
    public GameObject thoughtChosenVisual;
    public GameObject thoughtSpriteRef;
    public bool isConnectedToTheMurder;
    public Sprite[] sprites = new Sprite[7];
    private SpriteRenderer renderer;

    public Color shown;
    public Color notShown;

    private void Awake()
    {
        renderer = thoughtSpriteRef.GetComponent<SpriteRenderer>();
        readMindUI = canvas.GetComponent<ReadMindUI>();

        isChosen = false;

        thoughtChosenVisual.gameObject.SetActive(false);
    }
    private void Start()
    {
        switch (thoughtName)
        {
            case "GraduationHat":
                renderer.sprite = sprites[0];
                break;
            case "PaintingSupplies":
                renderer.sprite = sprites[1];
                break;
            case "Liquids":
                renderer.sprite = sprites[2];
                break;
            case "Idea":
                renderer.sprite = sprites[3];
                break;
            case "Apple":
                renderer.sprite = sprites[4];
                break;
            case "Cup":
                renderer.sprite = sprites[5];
                break;
            case "Money":
                renderer.sprite = sprites[6];
                break;
            case "Scissors":
                renderer.sprite = sprites[7];
                break;
        }

    }
    private void Update()
    {
        if (!isShown) renderer.color = notShown; else renderer.color = shown;

        if (isChosen && Input.GetMouseButtonDown(0)){
            print("this works");
            isShown = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cursor" && !isShown)
        {
            isChosen = true;

            CursorCode cursorCode = other.GetComponent<CursorCode>();
            readMindUI.UpdateTheText(true);
            cursorCode.investigate = true;
            thoughtChosenVisual.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Cursor")
        {
            isChosen = false;

            CursorCode cursorCode = other.GetComponent<CursorCode>();
            readMindUI.UpdateTheText(false);
            cursorCode.investigate = false;
            thoughtChosenVisual.gameObject.SetActive(false);
        }
    }
}

