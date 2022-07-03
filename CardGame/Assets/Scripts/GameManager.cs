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
            if(cardsOnBoard.Count != 0)
            {
               for(int i = 0; i < cardsOnBoard.Count; i++)
                {
                    cardsOnBoard[i].GetComponent<EnemyCard>().moveEnemyCardDown();
                }
            }
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                var randomSpawner = Random.Range(0, 4);
                var randomCard = Random.Range(0, spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards.Length);
                var cardTransform = spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[0].transform;
                //var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[Random.Range(0, 1)], spawnerLocation[randomSpawner].transform.position, spawnerLocation[randomSpawner].transform.rotation) as GameObject;
                var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[randomCard], spawnerLocation[randomSpawner].transform.position, cardTransform.rotation);
                cardsOnBoard.Add(spawnCard);
                Debug.Log("spawning cards");
            }
            enemyTurn = false;
            playerTurn = true;

        }
        if(gameState == 1 && playerTurn == true)
        {
            //todo
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerTurn = false;
                enemyTurn = true;
            }
         
            
        }
      

    }

    public void StartGame()
    {
        gameState = 1;

    }
}
