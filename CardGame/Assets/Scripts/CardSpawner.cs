using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSpawner : MonoBehaviour
{
    public CardInfo cardInfo;
    public CardInfo[] enemyStorage;



    public bool isMoving = false;
    public SpriteRenderer enemySprite;
    public int health;
    public TextMeshProUGUI name;
    public TextMeshProUGUI attackValue;
    public TextMeshProUGUI defenseValue;
    void Start()
    {
        var randomCard = Random.Range(0, enemyStorage.Length);
        cardInfo = enemyStorage[randomCard];
        enemySprite.sprite = cardInfo.cardImage;
        health = Random.Range(cardInfo.minHp, cardInfo.maxHp + 1);
        name.text = cardInfo.name.ToString();
        attackValue.text = this.health.ToString();
        


    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

  

    public void moveEnemyCardDown()
    {

        this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, 0, 2.5f);
        /*
        transform.DOMove(this.gameObject.transform.position - new Vector3(0, 0, 2.5f), 0.7f).OnComplete(() => {
            isMoving = false;
        });
        */


    }

    public void Attack()
    {
        Debug.Log("attacking");
    }
}
