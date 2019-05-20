using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtack : MonoBehaviour
{

    float speed = 5;
    float Damage = 25;
    public Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, 3);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag != "Monster")
        {
            Destroy(gameObject);
        }
        if(other.transform.tag == "Player")
        {
            target.SendMessage("SetDamage", Damage);
        }
    }
}