using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texts : MonoBehaviour
{
    public string[] scripts;

    public string[] Name;

    public string[] Yes;

    public string[] No;


    public Text mainText;
    public ExcelExample excelExample;

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
        if (Input.GetKeyDown(KeyCode.A)) {
            GetText(2);
        }
    }

    public void GetText(int index) {
        mainText.text = excelExample.dataArray[index].Name; 
    }

    
}
