using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int gameState;
    public static int ready;
    public Button startButton;
    public bool playerTurn = false;
    public bool enemyTurn = true;
    public List<GameObject> cardsOnBoard = new List<GameObject>();


    //Enemy Spanwer Variables
    public GameObject[] spawnerLocation;

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

        if(gameState == 1 && enemyTurn == true)
        {
            var randomSpawner = Random.Range(0, 4);
            var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[Random.Range(0, 1)], spawnerLocation[randomSpawner].transform.position, spawnerLocation[randomSpawner].transform.rotation) as GameObject;
            cardsOnBoard.Add(spawnCard);
            enemyTurn = false;
            playerTurn = true;

        }
        if(gameState == 1 && playerTurn == true)
        {
            //todo
            Debug.Log("player turn here");
            playerTurn = false;
            
        }
      

    }

    public void StartGame()
    {
        gameState = 1;

    }
}
