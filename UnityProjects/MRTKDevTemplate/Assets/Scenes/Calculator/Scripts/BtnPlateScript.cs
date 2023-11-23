using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPlateScript : MonoBehaviour
{
    public GameObject btn;
    public GameObject EquationLbl;
    public GameObject ResultLbl;

    public float currentResult = -1;
    public float currentA = 0;
    public float currentB = 0;

    private string[] btnsTxt = new string[]
    {
        "%", "CE", "C", "\u2190",
        "1/x", "x\u00b2", "\u221ax", "\u00F7",
        "7", "8", "9", "*",
        "4", "5", "6", "-",
        "3", "2", "1", "+",
        "\u00B1", "0", ".", "="
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < btnsTxt.Length; i++)
        {
            createBtn(btnsTxt[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject createBtn(string txt)
    {
        GameObject b = Instantiate(btn, new Vector3(0,0,0), Quaternion.identity);
        b.transform.localScale = Vector3.one;

        b.transform.parent = transform;

        b.GetComponent<BtnScript>().setTxt(txt);

        return b;
    }


}
