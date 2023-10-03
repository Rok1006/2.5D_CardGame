using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PateCatl : PlayerBase
{
    public PateCatl instance;
    public void Awake()
    {
        if(instance == null)
        {

            instance = this;
        }
       
    }
    public override async Task Attack()
    {
        _ = base.Attack();


        await Task.Yield();
        
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
        base.Start();
        vfx = this.GetComponent<FoxPersonVFX>();
    }

    // Update is called once per frame
    
}
