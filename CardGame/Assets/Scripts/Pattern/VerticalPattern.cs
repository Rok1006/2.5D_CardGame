using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Attack/VerticalSingle")]
public class VerticalPattern : AttackPattern, IAttack
{
    public override GameObject GetElement(int startX, int startY, GameObject[,] grid)
    {
        if (isEnemy == true)
        {

            int nextY = startY + 1;

            // Check if the previous row exists within the grid
            if (nextY >= 0)
            {
                if(grid[startX, nextY].GetComponent<Grid>().isOccupied == true)
                {
                    if(grid[startX, nextY].GetComponent<Grid>().thingHold.gameObject.tag == "Player")
                    {
                        return grid[startX, nextY];
                    }
                }
                return null;
            }
        }
        if (isPlayer == true)
        {
            int nextY = startY - 1;

            if (nextY >= 0)
            {
                return grid[startX, nextY];
            }
        }

        // Return an invalid value or handle the out-of-bounds case as desired
        return null;
    }
}
