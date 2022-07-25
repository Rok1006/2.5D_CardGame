using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
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
            playerList = gameManager.ReturnPlayer();
            PlayerSkill(playerList);


            GameManager.gameState = 1;
            GameManager.playerTurn = false;
            GameManager.enemyTurn = true;
            Debug.Log(GameManager.gameState);

        }
    }


    private void PlayerSkill(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var player = list[i].GetComponent<PlayerSkill>();
            player.Attack();
            player.Passive();
        }
    }
}
