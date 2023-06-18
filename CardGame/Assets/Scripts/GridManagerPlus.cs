using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerPlus : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject ground;
    public int gridSize = 4;
    public float cellSize = 2f;
    //change this
    public Queue<GameObject> queue = new Queue<GameObject>();

    public GameObject[,] grid;
    public Grid[,] enemyGrid;

    public static GridManagerPlus instance;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
             CreateGrid();
             enemyGrid = new Grid[gridSize, gridSize];
    }

    private void Update()
    {
        
    }

    private void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(z * cellSize, 0f, x * -cellSize);
                GameObject element = Instantiate(ground, transform.position + position, Quaternion.identity, transform);
                grid[z,x] = element;
                grid[z,x].AddComponent<Grid>();
                var gridelement = grid[z, x].GetComponent<Grid>();
                gridelement.row = z;
                gridelement.column = x;
            }
        }
        EstablishQueue();
        
    }

    private void EstablishQueue()
    {
        if (grid.GetLength(0) > 0)
        {
            while(queue.Count != 16)
            {
                Debug.Log("df");
                for(int i = gridSize - 1; i >= 0; i--)
                {
                    for(int j = 0; j < gridSize; j++)
                    {
                        var lastElement = grid[j, i];

                        // Put the last element from the first row into the queue
                        queue.Enqueue(lastElement);
                    }
                }
                
            }

        }
        else
        {
           // Debug.Log("Grid is empty!");
        }

    }
    public List<GameObject> PickRandomGridElement(int amount)
    {
        var current = 0;
        List<GameObject> list = new List<GameObject>();
        if(amount < enemyGrid.Length)
        {
            while(current < amount)
            {
                int randomRow = Random.Range(0, gridSize);
                int randomColumn = Random.Range(0, gridSize);

                GameObject randomElement = grid[randomRow, randomColumn];

                // Check if the element has already been picked
                if (!list.Contains(randomElement))
                {
                    list.Add(randomElement);
                    
                    //Debug.Log($"Picked element: {randomElement.name}");
                    current++;
                }
            }
           
        }

        return list;
    }

    public List<GameObject> PickRandomFirstRowElement(int amount)
    {
        var firstRowElements = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            firstRowElements.Add(grid[i,0]);
            Debug.Log(grid[i, 0].GetComponent<Grid>().row + " " + grid[i, 0].GetComponent<Grid>().column);
        }

        if(amount < firstRowElements.Count)
        {
            int num = firstRowElements.Count - amount;
            
            for(int i = 0; i < num; i++)
            {
                firstRowElements.RemoveAt(Random.Range(0, firstRowElements.Count));
            }

            
        }

        return firstRowElements;

    }

    public void InitialSpawnEnemy()
    {
        var list = PickRandomGridElement(3);
        foreach(GameObject smt in list)
        {
            var enemy = Instantiate(enemies[1], smt.transform.position , enemies[1].transform.rotation);
            var grid = smt.GetComponent<Grid>();
            grid.thingHold = enemy;
            grid.UpdateGrid();
            Debug.Log("grid:" + grid.row + " " + grid.column);
        }
    }
    public void SpawnEnemy()
    {
        var list =  PickRandomFirstRowElement(2);

        foreach(GameObject smt in list)
        {
            var enemy = Instantiate(enemies[1], smt.transform.position, enemies[1].transform.rotation);
            var grid = smt.GetComponent<Grid>();
            grid.thingHold = enemy;
            grid.UpdateGrid();
        }
    }

}
