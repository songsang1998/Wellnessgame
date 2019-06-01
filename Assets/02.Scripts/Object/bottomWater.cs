using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomWater : MonoBehaviour
{
    // Start is called before the first frame update


    public static Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            target.SendMessage("SetDamage", 100);
        }

    }
}

