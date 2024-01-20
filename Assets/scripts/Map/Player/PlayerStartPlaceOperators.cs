using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPlaceOperators : MonoBehaviour
{
    [SerializeField]
    GameObject attackerPrefab;

    [SerializeField]
    GameObject defenderPrefab;

    private GameObject usingOperatorPrefab;
    private List<GameObject> operators = new List<GameObject>();

    [SerializeField]
    private UserRegister userRegister;

    [SerializeField]
    private PlayerGameFlow gameFlow;

    private List<Vector2> operatorStartLocation = new List<Vector2>()
    {
        new Vector2(1, 2),
        new Vector2(2, 3),
        new Vector2(3, 4)
    };

    public List<GameObject> GetOperators(){return operators;}

    private class Identity
    {
        public const string DEFENDER = "defender";
        public const string ATTACKER = "attacker";
    }

    private void Start()
    {
        if (userRegister.GetPlayerIdentity() == Identity.DEFENDER) { usingOperatorPrefab = defenderPrefab; }
        else if (userRegister.GetPlayerIdentity() == Identity.ATTACKER) { usingOperatorPrefab = attackerPrefab;}

        foreach (Vector2 loc in operatorStartLocation)
        {
            GameObject oneOperator = Instantiate(usingOperatorPrefab, new Vector3(loc.y, 0, loc.x), Quaternion.identity);
            operators.Add(oneOperator);
        }

        gameFlow.StartGameFlow();


    }




}
