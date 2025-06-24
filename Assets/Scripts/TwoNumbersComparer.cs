using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstNumberField;
    [SerializeField] private TMP_InputField secondNumberField;
    [SerializeField] private TMP_Text resultText;

    private void SetResult(string value)
    {
        resultText.text = value;
    }

    public void Act()
    {
        try
        {
            float a = float.Parse(firstNumberField.text);
            float b = float.Parse(secondNumberField.text);

            string result = Compare(a, b);
            SetResult(result);
        }
        catch (Exception)
        {
            resultText.text = "������ ������";
        }
    }

    private string Compare(float a, float b)
    {
        string result = "�����";

        if (a > b)
        {
            result = a.ToString();
        } else if (b > a)
        {
            result = b.ToString();
        }

        return result;
    }
}
