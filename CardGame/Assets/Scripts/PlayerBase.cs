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
    protected List<GameObject> options = new List<GameObject>();

    private List<GameObject> targets;
    public Grid grid;
    protected GameObject[,] board = GridManagerPlus.instance.grid;
    





    // Start is called before the first frame update
    public virtual void Start()
    {
        board = GridManagerPlus.instance.grid;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DebugAttackPattern();
        }
    }
    public abstract Task OnDrag();



    public abstract Task Move();




    public abstract Task Attack();

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
            var potential = pattern.DebugAttack(this.grid.row, this.grid.column, GridManagerPlus.instance.grid);
           
            foreach(var element in potential)
            {
                options.Add(element);
                Instantiate(indicator, element.transform.position , Quaternion.identity);
            }
        }
        
    }
    
}
