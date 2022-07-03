using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardSpawner : MonoBehaviour
{
    public GameObject[] enemyCards;


    // Update is called once per frame
    void Update()
    {
       if(enemyCards == null)
        {
            Debug.Log("card array is empty");
        }
    }
}
