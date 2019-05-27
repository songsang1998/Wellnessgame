using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
    
{
    Player collidedPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        collidedPlayer = collider.gameObject.GetComponent<Player>();

        if (collidedPlayer == null) {
            return;
        }

        Destroy(this.gameObject);




    }

 


}
