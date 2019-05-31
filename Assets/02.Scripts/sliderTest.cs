using UnityEngine;
using System.Collections;
using UnityEngine.UI; //UGUI에 접근하려면 추가
public class sliderTest : MonoBehaviour
{

    public Slider progress;
    //Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        progress.value = Mathf.MoveTowards(progress.value, 1.0of, 0.01f);

    }
}
