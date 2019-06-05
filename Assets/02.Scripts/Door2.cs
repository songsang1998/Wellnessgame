using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door2 : MonoBehaviour
    
{
    AudioSource Door;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Door = GetComponent<AudioSource>();
            Debug.Log("door");
            Door.Play();
            SceneManager.LoadScene("Tutorial_map");

            
        }

    }


  
}
