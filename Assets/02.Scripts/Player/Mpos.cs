
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mpos : MonoBehaviour
{
    Player a;
    private void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Gun")
        {
            a.Pgun = true;
            Debug.Log("gun");
            a.anim.SetBool("gun", true);
        }



    }

}
