using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject CalculatorState;
    [SerializeField] private GameObject ComparatorState;

    private GameObject currentState;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveState(CalculatorState);
    }

    void ChangeState(GameObject newState)
    {
        if (currentState != null)
        {
            currentState.SetActive(false);
            SetActiveState(newState);
        }
    }

    void SetActiveState(GameObject newState)
    {
        currentState = newState;
        currentState.SetActive(true);
    }

    public void SetCalculatorState()
    {
        Debug.Log($"SetCalculatorState called at {Time.time}");
        ChangeState(CalculatorState);
    }

    public void SetComparatorState()
    {
        Debug.Log($"SetCalculatorState called at {Time.time}");
        ChangeState(ComparatorState); 
    }
}
