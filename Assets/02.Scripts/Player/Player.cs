 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    enum PlayerState {
       Wait=0,Run,Damage,die,Attack,Jump,Sit
    }

    Rigidbody2D rbody;
    Animator anim;
    SpriteRenderer spriteRenderer;
    Vector2 moveDir;


    PlayerState state=PlayerState.Run;
    float speedJump = 9;
    float gravity =20;
    bool isGround = true;
    int dir = 1;
    float keys;
    public bool Pgun = false;

    bool isUnBeatTime = false;

    Fire fire;



  

    void Awake()
    {
        InitPlayer();
      
    }
    void Update()
    {
        if (state != PlayerState.die)
        {
            Gun();
          
        }
    }
    void FixedUpdate()
    {
        Playergravity();
        if (state != PlayerState.die)
        {
            InputKey();
          
            Attack();
            SetAnimation();
            JumpPlayer();

            DeadCheck();
            Down();
           
        }
    }    

    private void Down()
    {
        if (state == PlayerState.Run)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetTrigger("sit");
                state = PlayerState.Sit;
                moveDir.x = 0;
            }
        }
        if (state == PlayerState.Sit)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetTrigger("up");
                state = PlayerState.Run;
            }

        }

    }
    void DeadCheck()
    {
        if (Hp <= 0 && state !=  PlayerState.die)
        {
            Die();
            isGround = false;
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
      
        if (other.transform.tag == "Gun")
        {
            Pgun = true;
            Debug.Log("gun");
            anim.SetBool("gun", true);
        }
        if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
        {

            isGround = true;
            moveDir.y = 0;
            anim.SetBool("Jumping", false);
            if (state == PlayerState.Jump) { 
                state = PlayerState.Run;
        }
        }
       

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (state != PlayerState.die)
        {

            if (other.gameObject.layer >= 8 && other.gameObject.layer <= 10)
            {
                isGround = false;
                anim.SetTrigger("Fall");
              
            }
        }
    }



    void Die()
    {
        anim.SetBool("Die", true);
        state = PlayerState.die;
        moveDir.x = 0;
    }

    // Update is called once per frame
    void InputKey()
    {
        if (state != PlayerState.Sit && state !=PlayerState.Attack)
        {
             keys = Input.GetAxis("Horizontal");
            moveDir.x = speed * keys;
            FlipPlayer(keys);
        }
        
    }
   
    void JumpPlayer()
    {
        
        if (isGround && Input.GetButton("Jump"))
        {
            state = PlayerState.Jump;
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
        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Run)
        {
            state = PlayerState.Attack;
            anim.SetTrigger("Attacking");
            StartCoroutine("Attacks");
            moveDir.x = 0;
        }
    }
    IEnumerator Attacks()
    {
        yield return new WaitForSeconds(1f);
        state = PlayerState.Run;
        anim.SetTrigger("Not Attacking");
    }
        void SetAnimation()
    {
        
        anim.SetFloat("speed", Mathf.Abs(moveDir.x));
    }
    void SetDamage(int mDamage)
    {
        if (state != PlayerState.die)
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
    }
    IEnumerator Hit()
    {
        
            anim.SetTrigger("Damage");
      Vector2 attackedVelocity;
        attackedVelocity = new Vector2(dir, 0.5f);
        rbody.AddForce(attackedVelocity, ForceMode2D.Impulse);
        
        
        yield return new WaitForSeconds(0.3f);
        state = PlayerState.Run;


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
        speed = 3.5f;
        Hp = 100;
    }
}
