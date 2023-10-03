using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Attack", menuName = "Attack/Random")]
public class RandomPattern : AttackPattern
{
    public bool isRowRandom;
    public bool isColumnRandom;
    public bool isAllRandom;
    public int numbers;

    public override List<GameObject> DebugAttack(int startX, int startY, ref GameObject[,] grid)
    {
        List<GameObject> result = new List<GameObject>();

        if (isRowRandom)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                result.Add(grid[startX, col]);
            }
        }

        if (isColumnRandom)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                result.Add(grid[row, startY]);
            }
        }

        if (isAllRandom)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    result.Add(grid[row, col]);
                }
            }
        }

        return result;
    }

    public override List<GameObject> GetElement(int startX, int startY, ref GameObject[,] grid)
    {
       
        options.Clear();
       
        int gridRows = grid.GetLength(0); // Get the number of rows in the grid
     
        int gridCols = grid.GetLength(1); // Get the number of columns in the grid
       
        for (int i = 0; i < numbers; i++)
        {
            if (isRowRandom)
            {
                int randomRow = Random.Range(0, gridRows);
                int randomCol = Random.Range(0, gridCols);
                options.Add(grid[1, randomCol]);
            }
            else if (isColumnRandom)
            {
                int randomRow = Random.Range(0, gridRows);
                int randomCol = Random.Range(0, gridCols);
                options.Add(grid[randomRow, 4]);
            }
            else if (isAllRandom)
            {
                int randomIndex = Random.Range(0, gridRows * gridCols);
                int rowIndex = randomIndex / gridCols;
                int colIndex = randomIndex % gridCols;
                options.Add(grid[rowIndex, colIndex]);
            }
        }
        Debug.Log(options.Count + "options Count");
        return options;
    }
}
