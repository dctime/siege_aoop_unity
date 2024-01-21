using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerGameFlow : MonoBehaviour
{
    private const string INDICATOR = "Indicator";

    private List<GameObject> operators;
    private int operatorsCount;

    private GameObject nowControlOperator = null;
    

    [SerializeField]
    private PlayerStartPlaceOperators startPlaceOperators;

    public void StartGameFlow()
    {
        operators = startPlaceOperators.GetOperators();
        foreach (GameObject operatorObject in operators)
        {
            operatorObject.GetComponent<OperatorClickEvent>().SetPlayerGameFlow(this);
        }

        operatorsCount = operators.Count;
        GetIndicatorFromOperator(operators[0]).SetActive(true);
        nowControlOperator = operators[0];
        
    }

    private int nowOperatorIndex = 0;
    // Use this to switch operator
    public GameObject GetNextOperator()
    {
        nowOperatorIndex++;
        if (nowOperatorIndex == operatorsCount)
        {
            Debug.Log("No more moves");
            GetIndicatorFromOperator(nowControlOperator).SetActive(false);
            nowControlOperator = null;
            return null;
        }

        GetIndicatorFromOperator(nowControlOperator).SetActive(false);
        nowControlOperator = operators[nowOperatorIndex];
        GetIndicatorFromOperator(nowControlOperator).SetActive(true);
        return nowControlOperator;
    }

    public GameObject GetIndicatorFromOperator(GameObject operatorObject)
    {
        return operatorObject.GetComponent<OperatorClickEvent>().GetIndicator();
    }

    public void WhenNowControllerOperatorIsClick()
    {
        GetNextOperator();
    }

    public void StartNextWave()
    {
        nowOperatorIndex = 0;
        nowControlOperator = operators[0];
        GetIndicatorFromOperator(operators[0]).SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            StartNextWave();
        }
    }

}
