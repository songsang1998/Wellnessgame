using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : MonoBehaviour
{

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Work() {

        Texts.instance.GetText(index);
        SpecialWork(); 
    }
    public virtual void SpecialWork() {

    }
}
