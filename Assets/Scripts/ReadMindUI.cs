using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReadMindUI : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    public TextMeshProUGUI thoughtAmountText;

    void Awake()
    {
        UpdateTheClickText(false);
        UpdateTheThoughtsReadText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene("InvestigationRoom");
    }

    public void UpdateTheClickText(bool tellToClick)
    {
        if (tellToClick) clickText.text = "Click to view thought."; else clickText.text= "Choose a thought to view.";
    }

    public void UpdateTheThoughtsReadText()
    {
        thoughtAmountText.text = ThoughtManager.thoughtsYouHaveRead.ToString() + "/" + ThoughtManager.maxThoughtsYouCanRead.ToString() + " of the thoughts read.";
    }

    public void Ok()
    {
        SceneManager.LoadScene("InvestigationRoom");
    }
}
