using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door1 : MonoBehaviour
{
    AudioSource Doors;
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Doors = GetComponent<AudioSource>();
            Doors.Play();
            SceneManager.LoadScene("bosoru_tutorial");
           

        }

    }
    

  
}
