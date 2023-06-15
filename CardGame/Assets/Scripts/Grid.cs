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



   
}
