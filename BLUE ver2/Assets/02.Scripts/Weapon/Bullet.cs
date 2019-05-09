using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    float speed =15;
    // Start is called before the first frame update
    void Awake()
    {
        

      
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
