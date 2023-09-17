using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using DG.Tweening;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject appearPrefab;
    public GameObject attackPrefab;
    public GameObject deathPrefab;
    public GameObject indicator;
    public GameObject DamagePrefab;

    public delegate void onMoveComplete();
    public event onMoveComplete moveComplete;

    public Stat stat;
    public SpriteRenderer enemySprite;
    public int health;

    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI attack;
    public List<EnemyMovement> movementPattern;
    public List<AttackPattern> attackPattern;
    public SpawnModifier mod;

    public delegate void MonsterDeathDelegate(EnemyBase enemy);
    public event MonsterDeathDelegate onMonsterDeath;

    
    public Grid grid;
    private Vector3 position;
    public Vector3 Position { get { return position; } set { position = value; } }
    public abstract Task Move();
    public abstract Task Attack();
    public abstract List<Vector3> EvaluateDestination();

    public abstract void MoveComplete();







    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemySprite.sprite = stat.cardImage;
        if (mod != null)
        {
            health = Mathf.RoundToInt(mod.enhanceEnemy * Random.Range(stat.minHp, stat.maxHp + 1));
        }
        else
        {
            health = Random.Range(stat.minHp, stat.maxHp + 1);
        }

        enemyName.text = stat.name.ToString();
        attack.text = this.health.ToString();
        
        StartCoroutine("Config");
    }


    // Update is called once per frame
    void Update()
    {

    }
    
    public int Calculation(Stat guest)
    {
        return (int)DamageCalculation.CalculateDamage(this.stat, guest);
        
    }


    public async Task Config()
    {
        var vfx = Instantiate(appearPrefab,transform.position, transform.rotation);
        var main = appearPrefab.GetComponent<ParticleSystem>().main;
        
        var duration = 1f;
        var durationInit = duration;
        
        bool tick = false;
        
        //while duration do something
        
        while (duration > 0)
        {
            
            duration -= Time.deltaTime;
            if (tick == false && duration < 0.5f)
            {
                tick = true;
                _ = Appear();
            }
            await Task.Yield();

        }
        
        
        
        

        

    }

   
    async Task Appear()
    {
        TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
        this.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 1f).OnComplete(() =>
        {

            taskCompletionSource.SetResult(true);
        });

        await taskCompletionSource.Task;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            var ground = other.gameObject.GetComponent<Grid>();
            ground.isOccupied = true;
            grid = ground;
            Position = ground.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            var ground = other.gameObject.GetComponent<Grid>();
            ground.isOccupied = false;
            grid = null;
            Position = Vector3.zero;
        }
    }
    public async Task Die()
    {
        onMonsterDeath?.Invoke(this);
        Destroy(this.gameObject);
        await Task.Yield();
    }
   

}
