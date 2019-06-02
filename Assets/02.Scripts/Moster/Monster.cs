using System.Collections;
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
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {

        target =  GameObject.FindWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        if (other.transform.name == "KPos")
        {
            state = MonsterState.Damage;
            Hp = -10;
            StartCoroutine("Hit");
        }

    }
    IEnumerator Hit()
    {
        int count;
        Hp = -10;
        for (count = 0; count < 10; count++)
        {

            if (count % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.1f);

            count++;
        }
        spriteRenderer.color = new Color(255, 255, 255, 255);
        state = MonsterState.Tracks;

    }

        public void OnCollisionStay2D (Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            target.SendMessage("SetDamage", Damage);
        }
       
    }
}
