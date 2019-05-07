using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
    
{

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
           
            
        }
    }
   
    
    
}
