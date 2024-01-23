using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    [SerializeField]
    UserRegister userRegister;

    [SerializeField]
    Text resultText;

    [SerializeField]
    Text scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        switch (userRegister.GetGameResult())
        {
            case "win":
                resultText.text = $"You Win!";
                break;

            case "lose":
                resultText.text = $"You lose";
                break;

            case "draw":
                resultText.text = $"Draw";
                break;
        }

        scoreBoard.text = $"{userRegister.GetSelfCount()} - {userRegister.GetEmenyCount()}";
    }
}
