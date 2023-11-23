using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.OpenXR.Features;

public class BtnScript : MonoBehaviour
{
    public TMP_Text btnTxt;

    public float theNum = -1;

    public GameObject btnPlate;
    public GameObject displayPlate;
    public BtnPlateScript bps;

    private LblManagerScript lbls;
    

    // Start is called before the first frame update
    void Start()
    {
        init();
        bps = btnPlate.GetComponent<BtnPlateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTxt(string txt)
    {
        btnTxt.text = txt;

        if (!float.TryParse(btnTxt.text, out theNum))
        {
            theNum = -1;
        }
    }

    public string getTxt()
    {
        return btnTxt.text;
    }

    private void init()
    {
        btnPlate = GameObject.Find("ButtonPlate");
        displayPlate = GameObject.Find("DisplayPlate");

        lbls = displayPlate.GetComponent<LblManagerScript>();
    }

    public void onClick()
    {
        if (theNum != -1)
        {
            lbls.addToResultLbl("" + theNum);
            return;
        }
        else
        {
            if (btnTxt.text == "%")
            {
                if (lbls.getEquTxt() != "")
                {
                    string[] strs = lbls.getEquTxt().Split(' ');
                    bps.currentA = float.Parse(strs[0]);
                }

                if (lbls.getResTxt() != "0")
                {
                    bps.currentB = float.Parse(lbls.getResTxt());
                }

                lbls.moveToEquationLbl();

                bps.currentResult = bps.currentA % bps.currentB;
            }
            else if (btnTxt.text == "CE")
            {
                lbls.clearResultLbl();
                bps.currentB = 0;
                bps.currentResult = 0;
            }
            else if (btnTxt.text == "C")
            {
                clear();
            }
            else if (btnTxt.text == "\u2190") // back
            {
                lbls.resBack();
            }

            else if (btnTxt.text == "1/x") // reciprocal
            {
                string s = lbls.getResTxt();

                lbls.clearAll();
                bps.currentA = float.Parse(s);
                bps.currentB = 0;
                

                lbls.addToEquationLbl("1/" + bps.currentA + " = ");
                if (bps.currentA == 0)
                {
                    lbls.addToResultLbl("undefined");
                }
                else
                {
                    bps.currentResult = 1 / bps.currentA;
                    lbls.addToResultLbl("" + bps.currentResult);
                }
                
            }
            else if (btnTxt.text == "x\u00b2") // square
            {
                string curr = lbls.getResTxt();

                bps.currentA = float.Parse(curr);
                bps.currentB = 0;
                bps.currentResult = bps.currentA * bps.currentA;

                lbls.clearEquationLbl();
                lbls.addToEquationLbl(curr + "\u00b2" + " = ");
                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);
            }
            else if (btnTxt.text == "\u221ax") // square root
            {
                string curr = lbls.getResTxt();

                bps.currentA = float.Parse(curr);
                bps.currentB = 0;
                bps.currentResult = Mathf.Sqrt(bps.currentA);

                lbls.clearEquationLbl();
                lbls.addToEquationLbl("\u221a" + curr + " = ");
                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);
            }
            else if (btnTxt.text == "\u00F7") // division
            {
                bps.currentB = float.Parse(lbls.getResTxt()); // b = bottom text

                if (lbls.getEquTxt() == "") // When Top Text IS empty
                {
                    lbls.addToEquationLbl(bps.currentB + " / ");
                    bps.currentA = bps.currentB;
                    bps.currentResult = bps.currentA / bps.currentB;
                    lbls.clearAll();
                    lbls.addToEquationLbl(bps.currentA + " / ");
                    lbls.addToResultLbl("" + bps.currentB);
                    return;
                }
                else //When Top Text is NOT empty
                {
                    bps.currentA = float.Parse(lbls.getEquTxt().Split(' ')[0]); //a = first substring of top text

                }


                bps.currentResult = bps.currentA / bps.currentB;    //Do math (minus)

                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);

                lbls.clearEquationLbl();
                lbls.addToEquationLbl(bps.currentResult + " / ");
            }

            else if (btnTxt.text == "*")
            {
                bps.currentB = float.Parse(lbls.getResTxt()); // b = bottom text

                if (lbls.getEquTxt() == "") // When Top Text IS empty
                {
                    lbls.addToEquationLbl(bps.currentB + " * ");
                    bps.currentA = bps.currentB;
                    bps.currentResult = bps.currentA * bps.currentB;
                    lbls.clearAll();
                    lbls.addToEquationLbl(bps.currentA + " * ");
                    lbls.addToResultLbl("" + bps.currentB);
                    return;
                }
                else //When Top Text is NOT empty
                {
                    bps.currentA = float.Parse(lbls.getEquTxt().Split(' ')[0]); //a = first substring of top text

                }


                bps.currentResult = bps.currentA * bps.currentB;    //Do math (multiply)

                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);

                lbls.clearEquationLbl();
                lbls.addToEquationLbl(bps.currentResult + " * ");
            }

            else if (btnTxt.text == "-")
            {
                bps.currentB = float.Parse(lbls.getResTxt()); // b = bottom text

                if (lbls.getEquTxt() == "") // When Top Text IS empty
                {
                    lbls.addToEquationLbl(bps.currentB + " - ");
                    bps.currentA = bps.currentB;
                    bps.currentResult = bps.currentA - bps.currentB;
                    lbls.clearAll();
                    lbls.addToEquationLbl(bps.currentA + " - ");
                    lbls.addToResultLbl("" + bps.currentB);
                    return;
                }
                else //When Top Text is NOT empty
                {
                    bps.currentA = float.Parse(lbls.getEquTxt().Split(' ')[0]); //a = first substring of top text

                }


                bps.currentResult = bps.currentA - bps.currentB;    //Do math (minus)

                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);

                lbls.clearEquationLbl();
                lbls.addToEquationLbl(bps.currentResult + " - ");
            }

            else if (btnTxt.text == "+")
            {
                bps.currentB = float.Parse(lbls.getResTxt()); // b = bottom text

                if (lbls.getEquTxt() == "") // When Top Text IS empty
                {
                    lbls.addToEquationLbl(bps.currentB + " + ");
                    bps.currentA = bps.currentB;
                    bps.currentResult = bps.currentA + bps.currentB;
                    lbls.clearAll();
                    lbls.addToEquationLbl(bps.currentA + " + ");
                    lbls.addToResultLbl("" + bps.currentB);
                    return;
                }
                else //When Top Text is NOT empty
                {
                    bps.currentA = float.Parse(lbls.getEquTxt().Split(' ')[0]); //a = first substring of top text
                    
                }

                
                bps.currentResult = bps.currentA + bps.currentB;    //Do math (plus)

                lbls.clearResultLbl();
                lbls.addToResultLbl("" + bps.currentResult);

                lbls.clearEquationLbl();
                lbls.addToEquationLbl(bps.currentResult + " + ");
            }

            else if (btnTxt.text == "\u00B1") // +-
            {
                float curr = float.Parse(lbls.getResTxt());

                curr *= -1;

                lbls.clearResultLbl();
                lbls.addToResultLbl("" + curr);
            }
            else if (btnTxt.text == ".")
            {
                lbls.addToResultLbl(".");
            }
            else if (btnTxt.text == "=")
            {
                if (lbls.getEquTxt() == "") //When top text is empty, move bottom result to top (even if it's 0)
                {
                    bps.currentResult = float.Parse(lbls.getResTxt());
                    bps.currentA = bps.currentResult;
                    bps.currentB = 0;
                    lbls.moveToEquationLbl();
                }
                else  //When top text has text already
                {
                    lbls.moveToEquationLbl();
                    lbls.addToEquationLbl(" = ");
                    lbls.addToResultLbl("" + bps.currentResult);
                }
            }
        }
    }

    private void clear()
    {
        lbls.clearAll();
        bps.currentA = 0;
        bps.currentB = 0;
        bps.currentResult = 0;
    }
}
