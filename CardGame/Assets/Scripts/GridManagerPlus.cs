using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerPlus : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject ground;
    public int gridSize = 4;
    public float cellSize = 2f;
    public Vector3 offset;
    //change this
    public Queue<GameObject> queue = new Queue<GameObject>();

    public GameObject[] playerGrid;
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
        grid = new GameObject[gridSize, 5];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(z * cellSize, 0f, x * -cellSize);
                GameObject element = Instantiate(ground, transform.position + position, Quaternion.identity, transform);
                grid[z,x] = element;
                grid[z,x].AddComponent<Grid>();
                //grid[z, x].GetComponent<MeshRenderer>().enabled = false;
                var gridelement = grid[z, x].GetComponent<Grid>();
                gridelement.row = z;
                gridelement.column = x;
                
            }
        }
        grid[0, 4] = GameObject.Find("PlayerGrid").transform.GetChild(0).gameObject;
        grid[1, 4] = GameObject.Find("PlayerGrid").transform.GetChild(1).gameObject;
        grid[2, 4] = GameObject.Find("PlayerGrid").transform.GetChild(2).gameObject;
        grid[3, 4] = GameObject.Find("PlayerGrid").transform.GetChild(3).gameObject;

        for (int i = 0; i < 4; i++)
        {
            //tbd
        }
        EstablishQueue();
        
    }

    public void EstablishQueue()
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
            if(grid[i,0].GetComponent<Grid>().isOccupied == false)
            {
                firstRowElements.Add(grid[i, 0]);
            }
            
            //Debug.Log(grid[i, 0].GetComponent<Grid>().row + " " + grid[i, 0].GetComponent<Grid>().column);
        }
        List<GameObject> pickedElements = new List<GameObject>();
        if (firstRowElements.Count >= amount)
        {

            
            if (amount <= firstRowElements.Count)
            {
                System.Random random = new System.Random();

                for (int i = 0; i < amount; i++)
                {
                    int randomIndex = random.Next(0, firstRowElements.Count);
                    pickedElements.Add(firstRowElements[randomIndex]);
                    firstRowElements.RemoveAt(randomIndex);
                }
            }

        }
        else
        {
            
        }

        return pickedElements;
    }


    public void InitialSpawnEnemy()
    {
        var list = PickRandomGridElement(3);
        foreach(GameObject smt in list)
        {
            var enemy = Instantiate(enemies[1], smt.transform.position + offset , enemies[1].transform.rotation);
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
            Debug.Log("meow");
            var enemy = Instantiate(enemies[1], smt.transform.position + offset, enemies[1].transform.rotation);
            var grid = smt.GetComponent<Grid>();
            grid.thingHold = enemy;
            grid.UpdateGrid();
        }
    }

}
