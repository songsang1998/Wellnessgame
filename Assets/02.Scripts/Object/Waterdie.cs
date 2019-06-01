using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdie : MonoBehaviour
{
    public static Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, 2);
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
