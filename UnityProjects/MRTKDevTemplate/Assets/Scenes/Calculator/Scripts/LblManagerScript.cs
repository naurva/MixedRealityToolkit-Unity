using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LblManagerScript : MonoBehaviour
{
    public TMP_Text EquationTxt;
    public TMP_Text ResultTxt;


    // Start is called before the first frame update
    void Start()
    {
        clearAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTxt(TMP_Text lblTxt, string str)
    {
        lblTxt.text = str;
    }

    public string getTxt(TMP_Text lblTxt)
    {
        return lblTxt.text;
    }

    public string getEquTxt()
    {
        return getTxt(EquationTxt);
    }
    public string getResTxt()
    {
        return getTxt(ResultTxt);
    }

    public void clear(TMP_Text lblTxt)
    {
        setTxt(lblTxt, "");
    }

    public void clearEquationLbl()
    {
        clear(EquationTxt);
    }

    public void clearResultLbl()
    {
        ResultTxt.text = "0";
    }

    public void addToLbl(TMP_Text lblTxt, string str)
    {
        lblTxt.text += str;
    }

    public void addToEquationLbl(string str)
    {
        addToLbl(EquationTxt, str);
    }
    public void addToResultLbl(string str)
    {
        if (ResultTxt.text == "0")
        {
            ResultTxt.SetText(str);
        }
        else
        {
            addToLbl(ResultTxt, str);
        }
        
    }

    public void moveToEquationLbl()
    {
        addToEquationLbl(getResTxt());
        clearResultLbl();
    }

    public void back(TMP_Text lblTxt)
    {
        string newTxt;
        if (lblTxt.text.Length <= 1)
        {
            if (lblTxt == ResultTxt)
                newTxt = "0";
            else
                newTxt = "";
        }
        else
        {
            newTxt = lblTxt.text.Substring(0, lblTxt.text.Length - 1);
        }

        lblTxt.text = newTxt;
    }

    public void equBack()
    {
        back(EquationTxt);
    }
    public void resBack()
    {
        back(ResultTxt);
    }
    public void clearAll()
    {
        clearEquationLbl();
        clearResultLbl();
    }
}
