using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    Transform target;
    Animator anim;
    float speed =3.5f;
    // Start is called before the first frame update
    void Awake()
    {
        InitG();
    }
    void Start()
    {
        target = GameObject.Find("player").transform;
        

    }
    
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            Vector2 dir = target.position - transform.position;

            if (dir.x > 2|| dir.x < -2)
            {
                transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
            }
            anim.SetFloat("G.x",Mathf.Abs(dir.x));
           

            if (dir.x >= 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else 
            {
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }
    void InitG()
    {

        anim = GetComponent<Animator>();
    }
}
