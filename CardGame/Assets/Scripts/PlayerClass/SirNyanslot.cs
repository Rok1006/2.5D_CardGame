using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SirNyanslot : PlayerBase
{
    
    
    public override Task Attack()
    {
        return null;
    }

    public override Task Move()
    {
        return null;
    }

    public override Task OnDrag()
    {
        return null;
    }

    public override Task Passive()
    {
        return null;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        vfx = this.GetComponent<DragonDudVFX>();
    }

    // Update is called once per frame
    
}
