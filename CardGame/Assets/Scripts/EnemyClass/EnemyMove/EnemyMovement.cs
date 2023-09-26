using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : ScriptableObject
{
    
    public Vector3 offset = new Vector3(0, 0.6f, 0);
    
    public abstract List<Vector3> Movement(int row, int column,GameObject host);

    public bool Validate(int row, int column)
    {

        
        return GridManagerPlus.instance.grid[row, column].gameObject.GetComponent<Grid>().isOccupied;

    }

}
