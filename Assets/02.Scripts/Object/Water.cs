using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    bool waterlive = false;
    GameObject waterleft;
    public Transform waterPos;
    private float fDestroyTime;
    private float fTickTime;

 

    void Awake()
    {
        fTickTime = 0;
        fDestroyTime = 2;
        waterleft = Resources.Load("droplet_1", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterrotate();
    }


    void waterrotate()
    {
       

      
         
            

            if (Time.time>fTickTime)
            {
                fTickTime = Time.time + fDestroyTime;
                Instantiate(waterleft, waterPos.position, Quaternion.identity);
                
            }
           
        
    }

}
