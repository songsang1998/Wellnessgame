 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform foot;
    Rigidbody2D rbody;
    Animator anim;
    float speedRun = 5;
    Vector2 moveDir;
    float speedJump = 11;
    float gravity =26;
    bool isGround = true;
    int dir = 1;
    LayerMask ground;
    bool Pgun = false;

    GameObject bullet;




    public Transform firePos;
    // Start is called before the first frame update
    void Awake()
    {
        InitPlayer();
         bullet =Resources.Load("bullet", typeof(GameObject)) as GameObject;
    }
 
    void FixedUpdate()
    {
        InputKey();
        MovePlayer();
        Attack();
        SetAnimation();
        JumpPlayer();
        Gun();
        
    }
    

  
    void Gun()
    {
        if (Pgun == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        Quaternion rotation = transform.rotation;
        if (transform.localScale.x > 0)
        {
            rotation.eulerAngles = new Vector3(0, 180, 0);
        }

       
        Instantiate(bullet, firePos.position, rotation);
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

    }

 
    void Die()
    {
        Destroy(this.gameObject);
    }
   
    // Update is called once per frame
    void InputKey()
    {
        float key = Input.GetAxis("Horizontal");
        moveDir.x = speedRun * key;
        Debug.Log(moveDir.x);
        anim.SetFloat("key", key);
        FlipPlayer(key);

    }
   
    void JumpPlayer()
    {
        CheckGround();
        if (isGround && Input.GetButton("Jump"))
        {
            moveDir.y = speedJump;
            isGround = false;
           
          
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
    void CheckGround()
    {
        if (Physics2D.OverlapCircle(foot.position, 0.1f, ground))
        {
           
            isGround = true;
            moveDir.y = -1;
           
        }
    }
    void MovePlayer()
    {
        moveDir.y -= gravity * Time.deltaTime;
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

    void InitPlayer()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ground = 1 << LayerMask.NameToLayer("Ground");
        

    }
}
