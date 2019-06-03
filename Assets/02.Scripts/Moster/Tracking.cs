using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    Monster mob;
    Vector3 playerPos;
    Vector2 dir;
    Vector3 moveVelocity = Vector3.zero;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Monster.target == null) return;
         playerPos = Monster.target.transform.position;
         dir = playerPos - transform.position;
        if (mob.state != Monster.MonsterState.Die && mob.state != Monster.MonsterState.Damage) {
            if (dir.x >= -5 && dir.x <= 5 )
            {
                mob.state = Monster.MonsterState.Tracks;
                anim.SetBool("Tracking", true);
                Tracks();

            }
            else
            {
                mob.state = Monster.MonsterState.Moves;
                anim.SetBool("Tracking", false);
            }
        }
      
    }

    void Tracks()
    {
        
        if (dir.x< 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
           
        }
        else
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
            
        }

        transform.position += moveVelocity * mob.speed * Time.deltaTime;
    }
}
