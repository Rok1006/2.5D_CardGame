using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PateCatl : PlayerBase
{
    
    public override async Task Attack()
    {
        isAttacking = true;
        var options = attackPattern[0].GetElement(grid.row , grid.column , board);
        if(options != null)
        {
            vfx.GetComponent<FoxPersonVFX>().currentState = FoxPersonVFX.AbilityState.MAIN;
            StartCoroutine(vfx.GetComponent<FoxPersonVFX>().Attack(this.gameObject));
            while (isAttacking != false)
            {
                Debug.Log(gameObject.name + " " + "attacking");
                await Task.Yield();
            }
        }
        
        
        await Move();
        
    }

    public override Task Move()
    {
        Debug.Log("meow");
        throw new System.NotImplementedException();
    }

    public override Task OnDrag()
    {
        throw new System.NotImplementedException();
    }

    public override Task Passive()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        vfx = this.GetComponent<FoxPersonVFX>();
    }

    // Update is called once per frame
    
}
