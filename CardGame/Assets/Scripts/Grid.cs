using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid :MonoBehaviour
{
    public bool isOccupied;
    public GameObject thingHold;
    public int row;
    public int column;

    public void UpdateGrid()
    {
        if(thingHold != null && thingHold.GetComponent<EnemyBase>())
        {
            this.isOccupied = true;
            thingHold.GetComponent<EnemyBase>().grid = this;
            thingHold.GetComponent<EnemyBase>().Position = this.gameObject.transform.position;


        }
        else
        {
            this.isOccupied = false;
            thingHold = null;
        }
    }

   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "EnemyCard")
        {
            if(collision.gameObject.tag == "EnemyCard")
            {
                collision.gameObject.GetComponent<EnemyBase>().grid = this;
            }
            thingHold = collision.gameObject;
            isOccupied = true;
        }
    }
   
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "EnemyCard")
        {
            thingHold = null;
            isOccupied = false;
        }
    }




}
