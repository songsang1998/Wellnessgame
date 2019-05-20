using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Character my;
    // Start is called before the first frame update
    void Start()
    {
      my = GetComponent<Character>();

    }

    // Update is called once per frame
    void Update()
    {
        if (my.Hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
