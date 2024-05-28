using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private UIActionElement[] uiActionElements;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HandleAction("Rock");
            Debug.Log("pressed");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            HandleAction("Paper");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            HandleAction("Scissors");
        }
    }

    private void HandleAction(string action){
        GameManager.Instance.ExecutePlayerAction(action);

        switch (action)
        {
            case "Rock":
                uiActionElements[0].Activate(); 
                break;
            case "Paper":
                uiActionElements[1].Activate();
                break;
            case "Scissors":
                uiActionElements[2].Activate();
                break;
            default:
                break;
        }
    }
}
