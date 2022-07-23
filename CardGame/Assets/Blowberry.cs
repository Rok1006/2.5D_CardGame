using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowberry : MonoBehaviour
{
    public bool isOnPassive1;
    public bool isOnPassive2;

    public bool isOnAttack1;
    public bool isOnAttack2;
    public GameObject[] row3;
    public float health;
    public float attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        //initialize base stats
    }

    // Update is called once per frame
    public void Attack()
    {
        if(isOnAttack1 == true)
        {
            for(int i = 0; i < 3; i++)
            {
                row3[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().health -= attackPoint;
            }
        }
        if (isOnAttack2 == true)
        {
            for (int i = 1; i < 4; i++)
            {
                row3[i].GetComponent<EnemyBoard>().whatIsOnBoard.GetComponent<EnemyCard>().health -= attackPoint;
            }
        }
    }

    public void Passive()
    {
        health += 5;
        attackPoint += 2;
    }
}
