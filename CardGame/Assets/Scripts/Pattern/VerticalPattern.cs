using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Attack/VerticalSingle")]
public class VerticalPattern : AttackPattern
{
    public override List<GameObject> DebugAttack(int startX, int startY, GameObject[,] grid)
    {
        return null;
    }

    public override List<GameObject> GetElement(int startX, int startY, GameObject[,] grid)
    {
        options.Clear();
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
                        options.Add(grid[startX, nextY]);
                        return options;
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
                options.Add(grid[startX, nextY]);
                return options;
            }
        }

        // Return an invalid value or handle the out-of-bounds case as desired
        return null;
    }
}
