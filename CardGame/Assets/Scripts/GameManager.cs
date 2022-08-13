using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] playerBoard;
    public static int gameState;
    public static int ready;
    public Button startButton;
    public Button playerTurnButton;
    public static bool playerTurn = false;
    public static bool enemyTurn = true;
    public List<GameObject> cardsOnBoard = new List<GameObject>();
    public GameObject[] row1, row2, row3;
    public bool canEnemyAttack;
    public List<GameObject> enemy = new List<GameObject>();

    private bool enemyAttackDone = false;
    private int counter = 3;

    public bool isRow3Empty;
    public bool isRow2Empty;
    //Enemy Spanwer Variables
    public List<GameObject> referenceSpawner = new List<GameObject>();
    public List<GameObject> spawnerLoc = new List<GameObject>();

    void Start()
    {
        //GameState 0 = pre game, GameState 1 = after player places all of the player pieces...
        gameState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == 4 && gameState == 0)
        {
            startButton.gameObject.SetActive(true);
        }
        // once all the player pieces are placed on board , change the gamestate to 1

        if (gameState == 1 && enemyTurn == true)
        {
            //enemy attack -> advance -> spawn
            CanEnemyAttack();
            if (canEnemyAttack == true)
            {
                Debug.Log("can attack");
                canEnemyAttack = false;
                EnemyAttack(enemy);
                MoveCard();
                SpawnCard();

            }
            else
            {
                Debug.Log("cant attack");
                MoveCard();
                SpawnCard();
            }

            enemyTurn = false;
            playerTurn = true;

        }
        if (gameState == 1 && playerTurn == true)
        {
            //player move -> player attack -> end turn
            gameState = 2;
            Debug.Log(gameState);
            playerTurnButton.gameObject.SetActive(true);
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
        startButton.gameObject.SetActive(false);

    }
    public void PlayerTurnButton()
    {
        gameState = 3;
        playerTurnButton.gameObject.SetActive(false);
        Debug.Log(gameState);

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

        if (counter == 4)
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

        for (int i = 0; i < enemy.Count; i++)
        {
            enemy[i].GetComponent<CardSpawner>().Attack();
        }
        enemy.Clear();

    }
    public List<GameObject> ReturnPlayer()
    {
        List<GameObject> players = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            players.Add(playerBoard[i].GetComponent<PlayerBoard>().whatIsOnThisBoard);
        }
        return players;
    }
    private void SpawnCard()
    {
        var random = Random.Range(1, 4);
        for (int i = 0; i < random; i++)
        {
            var randomSpawner = Random.Range(0, counter + 1);
            var randomCard = Random.Range(0, spawnerLoc[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards.Length);
            var cardTransform = spawnerLoc[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[0].transform;
            //var spawnCard = Instantiate(spawnerLocation[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[Random.Range(0, 1)], spawnerLocation[randomSpawner].transform.position, spawnerLocation[randomSpawner].transform.rotation) as GameObject;
            if (spawnerLoc[randomSpawner].GetComponent<EnemyBoard>().whatIsOnBoard == null)
            {
                var spawnCard = Instantiate(spawnerLoc[randomSpawner].GetComponent<EnemyCardSpawner>().enemyCards[randomCard], spawnerLoc[randomSpawner].transform.position + new Vector3(0, 1.6f, 0), cardTransform.rotation);
                cardsOnBoard.Add(spawnCard);
                spawnerLoc.RemoveAt(randomSpawner);
                counter--;
            }
            else if(spawnerLoc[randomSpawner].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                spawnerLoc.RemoveAt(randomSpawner);
                counter--;
            }




        }
        counter = 3;
        spawnerLoc = referenceSpawner.ToList();
        Debug.Log("copied");

    }

    private void CheckEmptyRow()
    {
        var counter = 0;
        for (int i = 0; i < row3.Length; i++)
        {
            if (row3[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
            {
                counter++;
            }
        }
        if (counter == 4)
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
        if (counter2 == 4)
        {
            isRow2Empty = true;

        }
    }

    public void MoveCard()
    {


        for (int i = 0; i < row2.Length; i++)
        {
            if (row2[i].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                if (row3[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
                {
                    row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<CardSpawner>().isMoving = true;
                    row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<CardSpawner>().moveEnemyCardDown();

                }

            }
        }
        for (int i = 0; i < row1.Length; i++)
        {
            if (row1[i].GetComponent<EnemyBoard>().whatIsOnBoard != null)
            {
                if (row2[i].GetComponent<EnemyBoard>().whatIsOnBoard == null)
                {

                    //row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving = true;
                    row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<CardSpawner>().moveEnemyCardDown();

                }
            }
            /* if (row2[i].GetComponent<EnemyBoard>().whatIsOnBoard != null && row2[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving == true)
             {

                 row1[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().moveEnemyCardDown();
                 row3[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().isMoving = false;
             }
            */

        }



    }

}
