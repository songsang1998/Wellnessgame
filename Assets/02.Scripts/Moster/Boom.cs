using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Monster
{
    Vector3 playerPos;
    Vector2 dir;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10;
        Damage = 70;
        speed =3;
        state = MonsterState.Wait;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Hp <= 0 && state != MonsterState.Die)
        {
            state = MonsterState.Die;
            anim.SetTrigger("Die");
            Invoke("Booms", 5);
        }
    }
    void Booms()
    {
        playerPos = target.transform.position;
        dir = playerPos - transform.position;
        if (dir.x >= -5 && dir.x <= 5)
        {

            target.SendMessage("SetDamage", Damage);
        }
        Invoke("Die", 3);
       
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public new void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);
        if (collision.transform.tag == "Player"&&state != MonsterState.Die)
        {
            
            Destroy(gameObject);
        }
    }
}
