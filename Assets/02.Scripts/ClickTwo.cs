using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTwo : MonoBehaviour
{
    // Start is called before the first frame update

    public int ID;
    public Texture2D cursorTexture;
    private Vector2 hotSpot;
    GameObject s;
    TextLoader pass2;
    static AudioSource r;
    private void Start()
    {

        hotSpot.x = cursorTexture.width / 2;
        hotSpot.y = cursorTexture.height / 2;
        s = GameObject.Find("Canvas/UI_object_research/2option");
        r = GameObject.Find("BGM/cusor").GetComponent<AudioSource>();
        pass2 = GetComponent<TextLoader>();
    }


    void OnMouseDown()
    {
        s.SetActive(true);
        pass2.Work2();
        r.Play();
    }




    public CursorMode cursorMode = CursorMode.Auto;

    void OnMouseEnter()
    {

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }



}
