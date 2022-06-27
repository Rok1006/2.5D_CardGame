using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int gameState;
   
    public static int ready;
    public Button startButton;
    void Start()
    {
        //GameState 0 = pre game, GameState 1 = after player places all of the player pieces...
        gameState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ready == 4)
        {
            startButton.gameObject.SetActive(true);
        }
        // once all the player pieces are placed on board , change the gamestate to 1


    }

    public void StartGame()
    {
        gameState = 1;
        Debug.Log("gamestate 1");
    }
}
