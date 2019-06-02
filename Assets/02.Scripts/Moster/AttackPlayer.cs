using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    Player a;
    
    
   // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
