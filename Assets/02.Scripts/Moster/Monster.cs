﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    public enum MonsterState
    {
        Wait = 0, Moves, Tracks, Die, Damage
    }

   public static Transform target;
    public MonsterState state;
    

    // Start is called before the first frame update
    void Awake()
    {

        target =  GameObject.FindWithTag("Player").GetComponent<Transform>();
        

    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Bullet")
        {
            Hp -= 15;
            

        }

    }
  

        public void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.transform.name == "player" && state != MonsterState.Die)
        {
            collision.gameObject.SendMessage("SetDamage", Damage);
        }
       
    }
}
