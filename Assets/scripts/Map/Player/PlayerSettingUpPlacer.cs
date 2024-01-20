using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSettingUpPlacer : MonoBehaviour
{
    [SerializeField]
    private UserRegister userRegister;

    [SerializeField]
    private GameObject attackerPrefab;

    private GameObject usingOperatorPrefab;

    [SerializeField]
    private GameObject defenderPrefab;

    public string identity;
    private BasePlaneClickEvent basePlaneClickEvent;

    private bool inSettingUp = true;
    private enum Identity
    {
        ATTACKER,
        DEFENDER
    }

    private Identity playerIdentity;

    private List<GameObject> playerOperators = new List<GameObject>();

    private void Start()
    {
        identity = userRegister.GetPlayerIdentity();
        identity = "attacker";
        Debug.Log($"User Identity: {identity}");
        Debug.Log("Remove this code from here!");

        if (identity == "attacker")
        {
            playerIdentity = Identity.ATTACKER;
            usingOperatorPrefab = attackerPrefab;
            Debug.Log($"Player Identity: {playerIdentity}");
        }
        else
        {
            playerIdentity = Identity.DEFENDER;
            usingOperatorPrefab = defenderPrefab;
            Debug.Log($"Player Identity: {playerIdentity}");
        }
    }

    private void GetBasePlaneClickEvent()
    {
        GameObject mapObject = GameObject.Find("Map");

        if (mapObject.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>() != null)
        {
            basePlaneClickEvent = mapObject.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>();
        }
        else
        {
            Debug.LogWarning("Cannot get map Object");
        }
    }

    public void basePlaneClickEventListener(float MapX, float MapY)
    {
        GameObject playerOperator = Instantiate(usingOperatorPrefab, new Vector3(MapY, 0, MapX), Quaternion.identity);
        playerOperators.Add(playerOperator);
    }

    private void Update()
    {
        if (basePlaneClickEvent == null)
        {
            GetBasePlaneClickEvent();
        }
        else
        {
            if (basePlaneClickEvent.GetPlayerSettingUpPlacer() == null)
            {
                basePlaneClickEvent.SetPlayerSettingUpPlacer(this);
            }
        }
    }
}
