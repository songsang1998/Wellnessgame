using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    Animator anim;
    bool s = false;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K) && s==false)
        {
            anim.SetTrigger("Open");
            s = true;
        }
        else if (Input.GetKeyDown(KeyCode.K) && s == true)
        {
            anim.SetTrigger("Close");
            s = false;
        }
    }
}
