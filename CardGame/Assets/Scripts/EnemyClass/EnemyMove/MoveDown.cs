using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Pattern", menuName = "Enemy/VerticalMovement")]
public class MoveDown : EnemyMovement
{
    
    public int min;
    public int max;
    public override List<Vector3> Movement(int row, int column,GameObject host)
    {
        var random = Random.Range(min, max + 1);
        if(column < 3)
        {
            var list = new List<Vector3>();
            list.Add(GridManagerPlus.instance.grid[row, column + random].transform.position + offset);
            
            return list;

        }
        else
        {
            var list = new List<Vector3>();
            list.Add(GridManagerPlus.instance.grid[row, column].transform.position + offset);
            return list;
        }
    }

    
}
