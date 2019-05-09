using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    bool waterlive = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterrotate();
    }


    void waterrotate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, -1, 1));
            if (waterlive == false)
            {
                Destroy(transform.Find("water").gameObject);
                waterlive = true;
            }
     
        }
    }
}
