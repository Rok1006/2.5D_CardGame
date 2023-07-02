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
    





    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
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
}
