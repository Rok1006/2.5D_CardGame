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
    public GameObject[] row1, row2, row3;
    public bool canEnemyAttack;
    public List<GameObject> enemy = new List<GameObject>();

    private bool enemyAttackDone = false;

    public bool isRow3Empty;
    public bool isRow2Empty;
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
            //enemy attack -> advance -> spawn
            CanEnemyAttack();
            if (canEnemyAttack == true)
            {
                canEnemyAttack = false;
                EnemyAttack(enemy);
                MoveCard();
                SpawnCard();

            }
            else
            {
                MoveCard();
                SpawnCard();
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
    private List<GameObject> CanEnemyAttack()
    {
        var counter = 0;
        
        for (int i = 0; i < row3.Length; i++)
        {
            if (row3[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
            {
                counter++;
            }
            if (row3[i].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                enemy.Add(row3[i].GetComponent<EnemyBoard>().whatIsOnBoard);
            }
        }

        if(counter == 5)
        {
            canEnemyAttack = false;
        }
        else
        {
            canEnemyAttack = true;
           
        }
        return enemy;
    }

    private void EnemyAttack(List<GameObject> enemy)
    {
        Debug.Log("attacking");
        for(int i = 0; i < enemy.Count; i++)
        {
            enemy[i].GetComponent<EnemyCard>().Attack();
        }
       
    }

    private void SpawnCard()
    {
       // CheckEmptyRow();
       // if(isRow3Empty == true)
      //  {
         //   Debug.Log("empty1");
        //    if(isRow2Empty == true)
         //   {
           //     Debug.Log("empty2");
                /*if (cardsOnBoard.Count != 0)
                {
                    for (int i = 0; i < cardsOnBoard.Count; i++)
                    {
                        cardsOnBoard[i].GetComponent<EnemyCard>().moveEnemyCardDown();
                    }
                }
                */
                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    var randomSpawner = Random.Range(0, 4);
                    var randomCard = Random.Range(0, spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards.Length);
                    var cardTransform = spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[0].transform;
                    //var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[Random.Range(0, 1)], spawnerLocation[randomSpawner].transform.position, spawnerLocation[randomSpawner].transform.rotation) as GameObject;
                    var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[randomCard], spawnerLocation[randomSpawner].transform.position + new Vector3(0,0.6f,0), cardTransform.rotation);
                    cardsOnBoard.Add(spawnCard);
                    Debug.Log("spawning cards");
                }
            //}
            
        //}
    }

    private void CheckEmptyRow()
    {
        var counter = 0;
        for(int i = 0; i < row3.Length; i++)
        {
            if(row3[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
            {
                counter++;
            }
        }
        if(counter == 5)
        {
            isRow3Empty = true;
        }
        var counter2 = 0;
        for (int i = 0; i < row3.Length; i++)
        {
            if (row2[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
            {
                counter2++;
            }
        }
        if (counter2 == 5)
        {
            isRow2Empty = true;
            
        }
    }

    public void MoveCard()
    {
        Debug.Log("moving");
        for(int i = 0; i < row2.Length; i++)
        {
            if(row2[i].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                if(row3[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
                {
                    row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving = true;
                    row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().moveEnemyCardDown();
                    
                }
                
            }
        }
        for (int i = 0; i < row2.Length; i++)
        {
            if (row1[i].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                if (row2[i].GetComponent<EnemyBoard>().whatIsOnBoard == null )
                {
                    row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving = true;
                    row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().moveEnemyCardDown();
                    
                }
            }
            if(row2[i].GetComponent<EnemyBoard>().whatIsOnBoard != null && row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving == true)
            {
                row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().moveEnemyCardDown();
            }
        }
    }
}
