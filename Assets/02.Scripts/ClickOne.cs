using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOne : MonoBehaviour
{
    public int ID;
    public Texture2D cursorTexture;
    private Vector2 hotSpot;
    static GameObject s;
    TextLoader pass1;
    static AudioSource r;
    private void Start()
    {
        
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        s = GameObject.Find("Canvas/UI_object_research/1option");
        r = GameObject.Find("BGM/cusor").GetComponent<AudioSource>();
        pass1 = GetComponent<TextLoader>();
    }
   
   
    void OnMouseDown()
    {
        s.SetActive(true);
        pass1.Work();
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
