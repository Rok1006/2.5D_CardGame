using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public abstract class PlayerBase : MonoBehaviour
{

    public Stat stat;
    public int health;
    public int mana;
    public int damage;
    public VFXBase vfx;
    public bool isAttacking = false;
    public List<AttackPattern> attackPattern;
    public GameObject indicator;
    public GameObject indicator2;
    protected List<GameObject> options = new List<GameObject>();

    private List<GameObject> targets;
    public Grid grid;
    protected GameObject[,] board;
    protected GridManagerPlus gm;
    





    // Start is called before the first frame update
    public virtual void Start()
    {
        gm = GridManagerPlus.instance;
        board = GridManagerPlus.instance.grid;
        vfx = this.gameObject.GetComponent<VFXBase>();
        EventHandler.Instance.OnTurnStart.AddListener(OnTurnStart);
        EventHandler.Instance.OnTurnFinished.AddListener(OnTurnEnd);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DebugAttackPattern();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _= Attack();
        }
    }
    public abstract Task OnDrag();



    




    public virtual async Task Attack()
    {
        isAttacking = true;
        int amount = 0;
        options.Clear();
        
        foreach (AttackPattern pattern in attackPattern)
        {
            amount += pattern.amount;
            
            var elements = pattern.GetElement(grid.row, grid.column, ref board);
            Debug.Log(elements.Count);
            foreach (var element in elements)
            {
                options.Add(element);
                Instantiate(indicator2, element.transform.position, Quaternion.identity);
                vfx.target.Add(element);
            }
            

        }
        await ProcessAttack();
        if (options != null)
        {
            //vfx.currentState = VFXBase.AbilityState.MAIN;
            //StartCoroutine(vfx.Attack(this.gameObject));
            while (isAttacking != false)
            {
                
                await Task.Yield();
            }
        }
        Debug.Log("task finished");

        await Task.Yield();
    }
    public abstract Task ProcessAttack();
    

    
    public virtual void OnTurnStart()
    {

    }
    public virtual void OnTurnEnd()
    {

    }
    
        

    public abstract Task Passive();
    

    
    private void OnMouseDrag()
    {
        
    }

    private void Init()
    {
       
    }
    
    protected virtual void DebugAttackPattern()
    {
        Debug.Log(this.gameObject.name);
        foreach(AttackPattern pattern in attackPattern)
        {
            var potential = pattern.DebugAttack(this.grid.row, this.grid.column, ref GridManagerPlus.instance.grid);
           
            foreach(var element in potential)
            {
                options.Add(element);
                Instantiate(indicator, element.transform.position , Quaternion.identity);
                options.Clear();
            }
        }
        
    }
    
}
