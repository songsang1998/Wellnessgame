using UnityEngine;
using System.Collections;
using UnityEngine.UI; //UGUI에 접근하려면 추가
public class sliderTest : MonoBehaviour
{
    Player obj;
    float hps;
    public Slider progress;
    //Use this for initialization
    private void Start()
    {

        
    }

    // Update is called once per frame
    private void Update()
    {
        progress = GetComponent<Slider>();
        obj = GameObject.FindWithTag("Player").GetComponent<Player>();
        hps = obj.Hp;
        progress.value = hps;
    }
}
