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
       progress = GetComponent<Slider>();
        obj = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        hps = obj.Hp;
        progress.value = hps;
    }
}
