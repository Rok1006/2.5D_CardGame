using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public string name;
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
    { /*
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
        */
        Debug.Log("attack");
    }

    public void Passive()
    {
        if (isOnPassive1 == true)
        {
            health = 5;
            attackPoint = 2;
        }
        if (isOnPassive2 == true)
        {
            health = 5;
            attackPoint = 2;
        }
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
