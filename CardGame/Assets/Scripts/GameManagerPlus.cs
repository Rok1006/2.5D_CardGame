using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManagerPlus : MonoBehaviour
{
    public bool isPlayerturn;
    public bool isEnemyturn;
    public  GridManagerPlus manager;


    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        manager = GridManagerPlus.instance;
        isPlayerturn = true;
        isEnemyturn = false;
        manager.InitialSpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isEnemyturn == true)
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                manager.SpawnEnemy();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
               enemies =  TurnManager.FillQueue(manager.queue);

                BeginTask();
            }
        }
        if(isPlayerturn == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                isPlayerturn = false;
                isEnemyturn = true;

            }
        }
        
    }

    public async void BeginTask()
    {
        
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<EnemyBase>() != null)
            {
                await enemy.GetComponent<EnemyBase>().Move();
                
            }
        }

        
        Debug.Log("finall");
        isEnemyturn = false;
        isPlayerturn = true;
    }
}
