using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    public Player player;
    public string name;
    public bool isOnPassive1;
    public bool isOnPassive2;

    public bool isOnAttack1;
    public bool isOnAttack2;
    public GameObject[] row3;
    public GameObject[] row2;


    private int NyanslotCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        
    }

    // Update is called once per frame
    public void Attack()
    {
        if (isOnAttack1 == true)
        {

            if (name == "Nyanslot")
            {
                var enemyDetect = gameObject.GetComponent<DragonDudVFX>();
                if (row3[0].GetComponent<EnemyBoard>().whatIsOnBoard != null)
                {
                    enemyDetect.leftEnemy = row3[0].GetComponent<EnemyBoard>().whatIsOnBoard.gameObject;
                }
                else
                {
                    Debug.Log("empty");
                }
                if (row3[2].GetComponent<EnemyBoard>().whatIsOnBoard != null)
                {
                    enemyDetect.rightEnemy = row3[2].GetComponent<EnemyBoard>().whatIsOnBoard.gameObject;
                }
                else
                {
                    Debug.Log("empty");
                }
                if (row3[1].GetComponent<EnemyBoard>().whatIsOnBoard != null)
                {
                    enemyDetect.frontEnemy = row3[1].GetComponent<EnemyBoard>().whatIsOnBoard.gameObject;
                }
                else
                {
                    Debug.Log("empty");
                }

                if (NyanslotCounter <= 2)
                {
                    if (enemyDetect.leftEnemy != null && enemyDetect.rightEnemy != null)
                    {

                        Debug.Log("using skill");
                        gameObject.GetComponent<DragonDudVFX>().StartCoroutine("Attack");
                        //NyanslotCounter++;
                    }

                }
            }



            if (name == "Zwei")
            {
                var enemyDetect = gameObject.GetComponent<BirdManVFX>();
                if (row3[1].GetComponent<EnemyBoard>().whatIsOnBoard != null && row2[1].GetComponent<EnemyBoard>().whatIsOnBoard != null)
                {
                    
                    enemyDetect.firstEnemy = row3[1].GetComponent<EnemyBoard>().whatIsOnBoard.gameObject;
                    enemyDetect.secondEnemy = row2[1].GetComponent<EnemyBoard>().whatIsOnBoard.gameObject;
                }
                else
                {
                    Debug.Log("bird cant attack sadge");
                }

                if(enemyDetect.firstEnemy != null && enemyDetect.secondEnemy != null)
                {
                    enemyDetect.StartCoroutine("Attack");
                }


            }
        }
    }
    public void Passive()
    {
        if (isOnPassive1 == true)
        {
            if(name == "Nyanslot")
            {
                player.AddDefense(5);
            }
            if(name == "BlowBerry")
            {
                player.AddAttack(1);
                player.AddHealth(5);
            }
            if(name == "Pate")
            {
                playerList[2].GetComponent<Player>().health += Random.Range(5, 11);
                playerList[3].GetComponent<Player>().health += Random.Range(1, 6);
            }
            if (name == "Zwei")
            {
                Debug.Log("vision range + 1");
            }
        }
        if (isOnPassive2 == true)
        {
            if (name == "Nyanslot")
            {
                player.AddDefense(5);
            }
            if (name == "BlowBerry")
            {
                player.AddAttack(1);
                player.AddHealth(5);
            }
            if (name == "Pate")
            {
                playerList[2].GetComponent<Player>().health += Random.Range(5, 11);
                playerList[3].GetComponent<Player>().health += Random.Range(1, 6);
            }
            if (name == "Zwei")
            {
                Debug.Log("vision range + 1");
            }
        }
    }

    public void UpdatePlayerList(List<GameObject> newPlayerList)
    {
        if(playerList != null)
        {
            playerList.Clear();
        }
        playerList = newPlayerList;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBoard")
        {
            if (other.gameObject.GetComponent<PlayerBoard>().id == 1)
            {
                isOnPassive1 = true;
            }
            if (other.gameObject.GetComponent<PlayerBoard>().id == 2)
            {
                isOnPassive2 = true;
            }
            if (other.gameObject.GetComponent<PlayerBoard>().id == 3)
            {
                isOnAttack1 = true;
            }
            if (other.gameObject.GetComponent<PlayerBoard>().id == 4)
            {
                isOnAttack2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerBoard")
        {
            isOnAttack1 = false;
            isOnAttack2 = false;
            isOnPassive1 = false;
            isOnPassive2 = false;
        }
    }
}
