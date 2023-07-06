using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<GameObject> enemies = new List<GameObject>();
    public static Queue players;


    public static List<GameObject> FillQueue(Queue<GameObject> queue)
    {
        enemies.Clear();
        while(queue.Count != 0)
        {
            if (queue.Peek().GetComponent<Grid>().isOccupied == true)
            {
                enemies.Add(queue.Dequeue().GetComponent<Grid>().thingHold);
            }
            else
            {
               queue.Dequeue();
            }
        }
       

        return enemies;
    }
}
