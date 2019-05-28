 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    enum PlayerState {
       Wait=0,Walk,Run,Damage,die
    }

    Rigidbody2D rbody;
    Animator anim;
    SpriteRenderer spriteRenderer;
    Vector2 moveDir;
    PlayerState state;
    float speedJump = 11;
    float gravity =26;
    bool isGround = true;
    int dir = 1;
    
    public bool Pgun = false;

    bool isUnBeatTime = false;

    Fire fire;



  

    void Awake()
    {
        InitPlayer();
      
    }
 
    void FixedUpdate()
    {
        InputKey();
       Playergravity();
        Attack();
        SetAnimation();
        JumpPlayer();
        Gun();
        DeadCheck();
    }
    void DeadCheck()
    {
        if (Hp <= 0 && state != PlayerState.die)
        {
            Die();
            
        }
    }
    
  
    void Gun()
    {
        if (Pgun == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
               fire.Fireing();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.name=="water")
        {
            Die();
            Debug.Log("you die");
        }
        if (other.transform.name == "Gun")
        {
            Pgun = true;
            Debug.Log("gun");
            anim.SetBool("gun", true);
        }
        if (other.gameObject.layer >=8 && other.gameObject.layer<=10)
        {
            
            isGround = true;
            moveDir.y = 0;
            anim.SetBool("Jumping", false);
        }
       

    }
    void OnTriggerExit2D(Collider2D other)
    {


        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {
            isGround = false;
            anim.SetTrigger("Fall");
        }
    }



    void Die()
    {
        Destroy(this.gameObject);
        state = PlayerState.die;
    }
   
    // Update is called once per frame
    void InputKey()
    {
       
        float key = Input.GetAxis("Horizontal");
        moveDir.x = speed * key;
       
        
        FlipPlayer(key);
        
    }
   
    void JumpPlayer()
    {
        
        if (isGround && Input.GetButton("Jump"))
        {
            
            moveDir.y = speedJump;
            anim.SetBool("Jumping", true);
            anim.SetTrigger("Jump");

        }
        
      
    }
    void FlipPlayer(float key)
    {
        if (key == 0) return;
        dir = (key > 0) ? -1 : 1;
        
        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale; 
    }

    void Playergravity()
    {

        
        if (isGround == false)
        {
            moveDir.y -= gravity * Time.deltaTime;
        }
        if (moveDir.y < 0)
        {
            anim.SetTrigger("Jump2");
        }
        if (state == PlayerState.Damage) return;
        rbody.MovePosition(rbody.position + moveDir * Time.deltaTime);
       

    }

  


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Attacking", true);
            
        }
        else
        {
            anim.SetBool("Attacking", false);
        }
    }
    void SetAnimation()
    {
        
        anim.SetFloat("speed", Mathf.Abs(moveDir.x));
    }
    void SetDamage(int mDamage)
    {
        
        if (!isUnBeatTime)
        {
            Hp -= mDamage;
            state = PlayerState.Damage;
            isUnBeatTime = true;
            StartCoroutine("BeatTime");
            StartCoroutine("Hit");
             
        }
    }
    IEnumerator Hit()
    {

        anim.SetTrigger("Damage");
      Vector2 attackedVelocity;
        attackedVelocity = new Vector2(2f*dir, 1f);
        rbody.AddForce(attackedVelocity, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        state = PlayerState.Wait;
      
        
    }
    IEnumerator BeatTime()
    {
        int count = 0;
      
        while (count < 10)
        {
            
            if (count % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            
            yield return new WaitForSeconds(0.3f);

            count++;
        }
        spriteRenderer.color = new Color(255, 255, 255, 255);
        
        isUnBeatTime = false;

        yield return null;
    }
    void InitPlayer()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fire = GetComponent<Fire>();
        speed = 5;
        Hp = 100;
    }
}
