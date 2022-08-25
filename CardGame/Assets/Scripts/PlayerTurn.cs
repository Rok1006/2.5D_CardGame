using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{

    public float timer = 3;
    public int counter = 0;
    public GameManager gameManager;
    public List<GameObject> playerList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.gameState == 3)
        {
            timer -= Time.deltaTime;

         
            if(timer < 0)
            {
                playerList = gameManager.ReturnPlayer();
                Debug.Log("asdf");
                PlayerSkill(playerList, counter);
                counter++;
                timer = 3;

                if(counter > 4)
                {
                    counter = 0;
                }
            }

            
           
          



        }
    }


    private void PlayerSkill(List<GameObject> list , int number)
    {

        if (counter < 4)
        {
            var player = list[number].GetComponent<PlayerSkill>();
            player.UpdatePlayerList(playerList);
            player.Attack();
            player.Passive();
            

        }
        else
        {
            GameManager.gameState = 1;
            GameManager.playerTurn = false;
            GameManager.enemyTurn = true;
            Debug.Log(GameManager.gameState);
            playerList.Clear();
        }
    }
}
