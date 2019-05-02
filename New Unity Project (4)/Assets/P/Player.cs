using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    float speedRun = 5;
    Vector2 moveDir;
    
    int dir = 1;
    // Start is called before the first frame update
    void Awake()
    {
        InitPlayer();
    }

    void FixedUpdate()
    {
        InputKey();
        MovePlayer();
        Attack();
        SetAnimation();
        
    }
    // Update is called once per frame
    void InputKey()
    {
        float key = Input.GetAxis("Horizontal");
        moveDir.x = speedRun * key;
        anim.SetFloat("key", key);
        FlipPlayer(key);

    }

    void FlipPlayer(float key)
    {
        if (key == 0) return;
        dir = (key > 0) ? -1 : 1;
        
        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale; 
    }
    void MovePlayer()
    {
        rbody.MovePosition(rbody.position + moveDir * Time.deltaTime);
  
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Attacking", true);
            Debug.Log("left mousebutton");
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
    }
}
