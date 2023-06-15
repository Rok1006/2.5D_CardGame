using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Pattern", menuName = "Enemy/VerticalMovement")]
public class MoveDown : EnemyMovement
{
    public int min;
    public int max;
    public override List<GameObject> Movement(int row, int column)
    {
        var random = Random.Range(min, max + 1);
        if(column < 3)
        {
            var list = new List<GameObject>();
            list.Add(GridManagerPlus.instance.grid[row, column + random]);
            Debug.Log(row + " " + column + random);
            return list;

        }
        else
        {
            return null;
        }
    }

    
}
