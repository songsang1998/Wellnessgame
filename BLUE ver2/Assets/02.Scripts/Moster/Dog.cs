using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Monster
{

    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        Damage = 25;
      
        state = MonsterState.Wait;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }


}
