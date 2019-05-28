using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject player;
    public Player playerstate;
    public Transform playerlocation;
    public Vector2 Savevector2;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerstate = player.GetComponent<Player>();
        playerlocation= player.GetComponent<Transform>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
           
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    public void Save()
    {
            
        
            PlayerPrefs.SetInt("Hp", playerstate.Hp);
        PlayerPrefs.SetInt("gun", (playerstate.Pgun ? 1:0));
        Savevector2 = new Vector2 (playerlocation.position.x, playerlocation.position.y);
            SetVector(Savevector2);
        Debug.Log(Savevector2);
        
    }
    public static void SetVector(Vector2 value)
    {
        PlayerPrefs.SetFloat("X", value.x);
        PlayerPrefs.SetFloat("Y", value.y);
    }
   
    public void Load()
    {
       
            playerstate.Hp = PlayerPrefs.GetInt("Hp");
          playerlocation.position = GetVector();
        playerstate.Pgun = (PlayerPrefs.GetInt("gun") != 0 ) ;
    }
    
    public static Vector2 GetVector()
    {
        Vector2 v2 = Vector2.zero;
        v2.x = PlayerPrefs.GetFloat("X");
        v2.y = PlayerPrefs.GetFloat("Y");
        
        return v2;
    }
    
}
