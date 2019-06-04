using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{


    public Text mainText1;
    public Text mainlog1;
    public Text yes1;
    public Text no2;
    public Text mainText2;
    public Text mainlog2;
    public Text yes2;
    public ExcelExample excelExample;
    int syes = 0;
    int sno = 0;
    int names = 0;
    public static Texts instance;
    private void Awake()
    {
        if (Texts.instance == null)
        {
            Texts.instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void GetText(int index, int log, int yes) {
        mainText1.text = excelExample.dataArray[index].Name;
        mainlog1.text = excelExample.dataArray[log].Name;
        yes1.text = excelExample.dataArray[yes].Name;
        syes = yes;
        names=index;
    }
    public void GetText2(int index, int log, int yes, int no)
    {
        mainText2.text = excelExample.dataArray[index].Name;
        mainlog2.text = excelExample.dataArray[log].Name;
        yes2.text = excelExample.dataArray[yes].Name;
        no2.text = excelExample.dataArray[no].Name;
        syes = yes;
        sno = no;
        names = index;
    }

    public void Close()
    {
        if (names == 25)
        {
            GetText(27, 28, 3);
        }
        else if (names == 27)
        {
            GetText(29, 30, 3);
        }
        else if (names == 33)
        {
            GetText(18, 37, 3);
            
        }
        else
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(false);
        }

        }

    public void Yes()
    {
        if (names == 0)
        {
            GameObject.Find("investigate_setin/black").SetActive(false);
        }
        if (names == 9)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(12, 13, 3);
        }
        if (names == 16)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(16, 20, 3);
        }
        if (names == 21)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(21, 22, 3);

        }
        if (names == 23)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(25, 26, 3);

        }
        if (names == 33)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(33, 36, 18);
        }
        if (syes == 6)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(7, 8, 3);
        }

        GameObject.Find("Canvas/UI_object_research/2option").SetActive(false);

    }
    public void No()
    {
        if (sno == 3 || sno == 19)
        {
            GameObject.Find("Canvas/UI_object_research/2option").SetActive(false);
        }
        if (names == 16)
        {
            GameObject.Find("Canvas/UI_object_research/1option").SetActive(true);
            GetText(16, 20, 3);
        }
        
    }
}
