using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Pattern", menuName = "Enemy/DiagonalMovement")]
public class MoveDiagonal : EnemyMovement
{
    public int min;
    public int max;
    public bool mix;
    private float previousDirection = -1;

    public override List<Vector3> Movement(int row, int column, GameObject host)
    {
        var random = Random.Range(min, max + 1);
        if (column < 3 && row < 3 && mix)
        {
            bool direction = Random.value > 0.5 ? true : false;
            //direction true = right, direction false = left
            var list = new List<Vector3>();
            if (direction)
            {
                list.Add(GridManagerPlus.instance.grid[row + random, column + random].transform.position + offset);
            }
            else
            {
                list.Add(GridManagerPlus.instance.grid[row - random, column + random].transform.position + offset);
            }

            return list;

        }
        /*
        if(column < 3 && row < 3 && !mix)
        {
            if(previousDirection == -1)
            {
                previousDirection = Random.value > 0.5 ? 1 : 0;
            }
            
            //direction true = right, direction false = left
            var list = new List<Vector3>();
            if ( previousDirection == 1)
            {
                if (GridManagerPlus.instance.grid[row + random, column + random].GetComponent<Grid>().thingHold == null)
                {
                    list.Add(GridManagerPlus.instance.grid[row + random, column + random].transform.position + offset);
                }
               
            }
            else
            {
                list.Add(GridManagerPlus.instance.grid[row - random, column + random].transform.position + offset);
            }
        }
        */
        else
        {
            var list = new List<Vector3>();
            list.Add(GridManagerPlus.instance.grid[row, column].transform.position + offset);
            return list;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
