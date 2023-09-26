using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManagerPlus : MonoBehaviour
{
    public bool isPlayerturn;
    public bool isEnemyturn;
    public  GridManagerPlus manager;
    private bool CardDrawn = false;

    

    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        
        manager = GridManagerPlus.instance;
        isPlayerturn = true;
        isEnemyturn = false;
        PlayerTurn();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("JoonTest");
        }
       
       
        
    }
    private void EnemyTurn()
    {
        
        if (enemies.Count != 0)
        {
            enemies.Clear();
        }
        enemies = TurnManager.FillQueue(manager.queue);

        BeginTask();
        manager.EstablishQueue();

    }
    private void PlayerTurn()
    {
        EventHandler.Instance.OnTurnStart.Invoke();
        Debug.Log("hi");
          
    }

    public async void BeginTask()
    {
        
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<EnemyBase>() != null)
            {
                await enemy.GetComponent<EnemyBase>().Move();
                await enemy.GetComponent<EnemyBase>().Attack();
                
            }
        }
        manager.SpawnEnemy();

        Debug.Log("finall");
        SwitchTurn();
    }
    public void SwitchTurn()
    {
        isPlayerturn = !isPlayerturn;
        isEnemyturn = !isEnemyturn;

        if (isPlayerturn)
        {
            PlayerTurn();
        }
        if (isEnemyturn)
        {
            EnemyTurn();
        }
    }
}
