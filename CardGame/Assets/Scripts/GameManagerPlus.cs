using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManagerPlus : MonoBehaviour
{
    bool isPlayerturn;
    bool isEnemyturn;
    public  GridManagerPlus manager;


    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        manager = GridManagerPlus.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
           enemies =  TurnManager.FillQueue(manager.queue);

            BeginTask();
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
    }
}
