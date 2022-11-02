using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReadMindUI : MonoBehaviour
{
    public TextMeshProUGUI clickText;

    void Awake()
    {
        UpdateTheText(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene("InvestigationRoom");
    }

    public void UpdateTheText(bool tellToClick)
    {
        if (tellToClick) clickText.text = "Click to view thought."; else clickText.text= "Choose a thought to view.";
    }

    public void Ok()
    {
        SceneManager.LoadScene("InvestigationRoom");
    }
}
