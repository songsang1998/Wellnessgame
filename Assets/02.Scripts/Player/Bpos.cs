
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bpos : MonoBehaviour
{
    Player a;
    private void Start()
    {
        a = gameObject.transform.parent.GetComponent<Player>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {
           
            a.isGround = true;
            a.anim.SetBool("isground", true);
            a.moveDir.y = 0;
            a.anim.SetBool("Jumping", false);
            if (a.state == Player.PlayerState.Fall)
            {
                a.state = Player.PlayerState.Run;
            }

        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (a.state != Player.PlayerState.die)
        {
           

            if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
            {
                a.isGround = false;
                a.anim.SetTrigger("Fall");
                a.anim.SetBool("isground", false);

            }
        }
    }

}
