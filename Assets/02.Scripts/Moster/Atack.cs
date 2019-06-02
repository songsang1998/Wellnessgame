using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    Monster mob;
    Vector3 playerPos;
    Vector2 dir;
    Vector3 moveVelocity = Vector3.zero;
    Animator anim;
    GameObject MonsterBullet;
    public Transform firePos;
    bool bulletis = true;

    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<Monster>();
        anim = GetComponent<Animator>();
        MonsterBullet = Resources.Load("MonsterBullet", typeof(GameObject)) as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Monster.target == null) return;
        playerPos = Monster.target.transform.position;
        dir = playerPos - transform.position;

        if (dir.x >= -7 && dir.x <= 7 && mob.state != Monster.MonsterState.Die && mob.state != Monster.MonsterState.Damage)
        {
            mob.state = Monster.MonsterState.Tracks;
            anim.SetBool("Atacking", true);
            Atacks();
            if (bulletis == true)
            {
                bulletis = false;
                StartCoroutine("Monsteratack");
            }
        }
        else
        {
            mob.state = Monster.MonsterState.Moves;
            anim.SetBool("Atacking", false);
        }
    }

    IEnumerator Monsteratack()
    {
        Quaternion rotation = transform.rotation;
        if (transform.localScale.x > 0)
        {
            rotation.eulerAngles = new Vector3(0, 180, 0);
        }

        GameObject ins = Instantiate(MonsterBullet, firePos.position, rotation);
        yield return new WaitForSeconds(0.5f);
        bulletis = true;

    }
   
    void Atacks()
    {
        Debug.Log(dir.x);
        if (dir.x < 0)
        {
            
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
           
            transform.localScale = new Vector3(-1, 1, 1);

        }

        
    }
}
