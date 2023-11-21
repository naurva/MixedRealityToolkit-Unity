using MixedReality.Toolkit.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Schema;
using UnityEditor;
//using UnityEditor.UIElements;
using UnityEngine;

using static MyCalculatorUIManager;

public class MyCalculator : MonoBehaviour
{
    #region CUSTOM EVENTS
    public delegate void CalculatorStarted();
    public static event CalculatorStarted OnCalculatorStarted;

    public delegate void UpdateExpressionDisplay(string value);
    public static event UpdateExpressionDisplay OnUpdateExpressionDisplay;

    public delegate void UpdateExpressionResult(string value);
    public static event UpdateExpressionResult OnUpdateExpressionResult;
    #endregion

    [SerializeField] private string CalculatorExpression = string.Empty;
    [SerializeField] private float CalculatorRunningTotal = 0f;
    [SerializeField] private float PreviousValue = 0f;
    [SerializeField] private float CurrentValue = 0f;

    private void OnEnable()
    {
        MyCalculatorUIManager.OnMyButtonElementPressed += MyCalculatorUIManager_OnMyButtonElementPressed;        
    }

    private void OnDisable()
    {
        MyCalculatorUIManager.OnMyButtonElementPressed -= MyCalculatorUIManager_OnMyButtonElementPressed;
    }

    private void MyCalculatorUIManager_OnMyButtonElementPressed(MyCalculatorUIManager.MyButtonElement value)
    {
        Debug.Log($"You click the button with value of {value.Caption} and of type {value.Type}");

        // determine what you want to do ...
        switch (value.Type)
        {
            case ButtonType.Numeric:
                {                    
                    // do the numeric stuff ...
                    CalculatorExpression += value.Caption;
                    break;
                }
            case ButtonType.Operation:
                {
                    //PreviousValue = float.Parse(CalculatorExpression);
                    // do the operation stuff ...
                    switch (value.Caption)
                    {
                        case "+":
                        case "-":
                        case "/":
                        case "*":
                            {
                                CalculatorExpression += value.Caption;
                                break;
                            }
                        case "=":
                            {
                                // computer the expression ...
                                bool ok = ExpressionEvaluator.Evaluate(CalculatorExpression, out float r);
                                Debug.Log($"Expression: {CalculatorExpression} -> Result: {r}");
                                OnUpdateExpressionResult?.Invoke(r.ToString());
                                CalculatorExpression = r.ToString();
                                OnUpdateExpressionDisplay?.Invoke("");
                                break;
                            }
                    }
                    break;
                }
            default:
                {
                    Debug.Log("Operation not supported ...");
                    break;
                }
        }

        OnUpdateExpressionDisplay?.Invoke( CalculatorExpression );
    }

    private void Start()
    {
        OnCalculatorStarted?.Invoke();
    }
}
