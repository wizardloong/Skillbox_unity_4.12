using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstNumberField;
    [SerializeField] private TMP_InputField secondNumberField;
    [SerializeField] private TMP_Text resultText;

    private void SetResult(float value)
    {
        resultText.text = value.ToString();
    }

    private readonly Dictionary<string, Func<float, float, float>> operations = new()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => b != 0 ? a / b : throw new DivideByZeroException() }
    };

    public void ActionCalculate(string op)
    {
        try
        {
            float a = float.Parse(firstNumberField.text);
            float b = float.Parse(secondNumberField.text);

            if (!operations.TryGetValue(op, out var operation))
            {
                resultText.text = $"Неизвестная операция: {op}";
                return;
            }

            float result = operation(a, b);
            SetResult(result);
        }
        catch (DivideByZeroException)
        {
            resultText.text = "Делить на ноль нельзя";
        }
        catch (Exception)
        {
            resultText.text = "Плохие данные";
        }
    }
}
