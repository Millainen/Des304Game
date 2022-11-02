using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCode : MonoBehaviour
{
    public GameObject cursorNormal, cursorInvestigate;
    public bool investigate;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        CursorFollowsMouse();
        MouseState();
    }

    void CursorFollowsMouse()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;
        transform.position = newPos;
    }

    void MouseState()
    {
        cursorNormal.gameObject.SetActive(!investigate);
        cursorInvestigate.gameObject.SetActive(investigate);
    }
}
