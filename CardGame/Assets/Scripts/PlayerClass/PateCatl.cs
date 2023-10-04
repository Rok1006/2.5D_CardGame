using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PateCatl : PlayerBase
{
    public PateCatl instance;
    private float heal = 3;
    private int healAmount = 1;
    public GameObject healCircle;
    public List<GameObject> list = new List<GameObject>();
    public GameObject vfxx;

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

    public override async Task ProcessAttack()
    {
        Debug.Log("processing");
        gm.PickRandomPlayers(ref list, healAmount, true);
        
        foreach(var character in list)
        {
            vfxx = Instantiate(healCircle, character.transform.position , healCircle.transform.rotation) as GameObject;
           // DamageCalculation.Heal(this.stat , character.GetComponent<Grid>().thingHold.GetComponent<PlayerBase>().stat);
        }
        while(vfxx != null)
        {
            Debug.Log("am i stuck here");
            await Task.Yield();
        }
        isAttacking = false;
        Debug.Log("done cat");
        await Task.Yield();
        
    }

    // Update is called once per frame

}
