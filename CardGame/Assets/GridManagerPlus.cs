using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerPlus : MonoBehaviour
{
    public GameObject ground;
    public int gridSize = 4;
    public float cellSize = 2f;

    private GameObject[,] grid;

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(z * cellSize, 0f, x * -cellSize);
                GameObject enemy = Instantiate(ground, transform.position + position, Quaternion.identity, transform);
                grid[x, z] = enemy;
            }
        }
    }

}
