 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

   public enum PlayerState {
       Wait=0,Run,Damage,die,Attack,Jump,Sit,Fall,SitAttack
    }

    Rigidbody2D rbody;
   public Animator anim;
    SpriteRenderer spriteRenderer;
   public Vector2 moveDir;
    AttackPlayer Attackpos;
    Kpos Kchild;
    Kpos SKchild;
    public PlayerState state=PlayerState.Run;
    float speedJump = 9;
    float gravity =20;
    public bool isGround = false;
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
            Attack();
            SitAttack();
            DeadCheck();
            Down();
            SetAnimation();

        }
    }
    void FixedUpdate()
    {
        Playergravity();
        if (state != PlayerState.die)
        {
            InputKey();
            
            
            JumpPlayer();



        }
    }    

    private void Down()
    {
      
            if (Input.GetKey(KeyCode.DownArrow)&& state == PlayerState.Run)
            {
                anim.SetBool("sit",true);
                state = PlayerState.Sit;
                moveDir.x = 0;
            }
        
        
            if (Input.GetKey(KeyCode.DownArrow)==false&& state==PlayerState.Sit)
            {
                anim.SetBool("sit",false);
                state = PlayerState.Run;
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




    void Die()
    {
        anim.SetBool("Die", true);
        state = PlayerState.die;
        moveDir.x = 0;
    }

    // Update is called once per frame
    void InputKey()
    {
        if (state != PlayerState.Sit && state !=PlayerState.Attack && state != PlayerState.SitAttack)
        {
             keys = Input.GetAxis("Horizontal");
            moveDir.x = speed * keys;
            FlipPlayer(keys);
        }
        
    }
   
    void JumpPlayer()
    {
        
        if (isGround && Input.GetButton("Jump")&&state!=PlayerState.Sit && state!=PlayerState.Attack && state != PlayerState.SitAttack)
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

        if (moveDir.y < 0 && state== PlayerState.Jump)
        {
            anim.SetTrigger("Jump2");
            state = PlayerState.Fall;
        }
        if (state == PlayerState.Damage) return;
        rbody.MovePosition(rbody.position + moveDir * Time.deltaTime);
       

    }

  

   
    void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Run )
        {
            state = PlayerState.Attack;
            anim.SetTrigger("Attacking");
            moveDir.x = 0;
            StartCoroutine(Attackis());

            
        }
    }

    void SitAttack()
    {

        if (Input.GetKeyDown(KeyCode.Z) && state == PlayerState.Sit)
        {
            Debug.Log("sitattack");
            state = PlayerState.SitAttack;
            anim.SetTrigger("Attacking");
            StartCoroutine(SAttackForIt());


        }
    }
    IEnumerator Attackis()
    {
        yield return new WaitForSeconds(0.5f);
        if (state == PlayerState.Attack)
        {
            Kchild.kp.enabled = true;
            StartCoroutine(PWaitForIt());
        }
        
       
    }
    IEnumerator PWaitForIt()
    {
        yield return new WaitForSeconds(0.5f);
        if (state == PlayerState.Attack)
        {
            state = PlayerState.Run;
            if (Kchild.kp.enabled == true)
            {
                Kchild.kp.enabled = false;
            }
        }
        else if (Kchild.kp.enabled == true)
        {
                Kchild.kp.enabled = false;
            }       
    }
    IEnumerator SAttackForIt()
    {
            SKchild.kp.enabled = true;      
        yield return new WaitForSeconds(0.5f);
        if (state == PlayerState.SitAttack)
        {
            state = PlayerState.Sit;
            if (SKchild.kp.enabled == true)
            {
                SKchild.kp.enabled = false;
            }
        }
        else if (SKchild.kp.enabled == true)
        {
            SKchild.kp.enabled = false;
        }
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
        rbody.velocity = Vector2.zero;
        anim.SetTrigger("Damage");
      Vector2 attackedVelocity;
        attackedVelocity = new Vector2(dir, 0.5f);
        rbody.AddForce(attackedVelocity, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("sit", false);
        state = PlayerState.Run;

        
    }
    IEnumerator BeatTime()
    {
        int count = 0;
      
      for (count=0;count < 10; count++)
        {

            if (count % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);

            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255,180);
            }
            yield return new WaitForSeconds(0.2f);

           
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
        Kchild=GameObject.Find("KPos").GetComponent<Kpos>();
        SKchild = GameObject.Find("SKPos").GetComponent<Kpos>();
    }
}
