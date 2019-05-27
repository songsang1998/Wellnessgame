using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    GameObject bullet;
    public Transform firePos;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load("bullet", typeof(GameObject)) as GameObject;
        
     }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fireing()
    {
        Quaternion rotation = transform.rotation;
        if (transform.localScale.x > 0)
        {
            rotation.eulerAngles = new Vector3(0, 180, 0);
        }

        GameObject ins = Instantiate(bullet, firePos.position, rotation);

    }
}
