using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SirNyanslot : PlayerBase
{
    private int turnCount = 0;

    
    public override Task Attack()
    {
        return null;
    }

    

    public override Task OnDrag()
    {
        return null;
    }
    public override void OnTurnEnd()
    {
        base.OnTurnEnd();
        turnCount++;
    }
    public override Task Passive()
    {
        return null;
    }

    public override Task ProcessAttack()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        vfx = this.GetComponent<DragonDudVFX>();
    }

    // Update is called once per frame
    
}
