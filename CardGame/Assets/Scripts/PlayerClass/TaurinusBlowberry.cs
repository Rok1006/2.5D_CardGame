using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TaurinusBlowberry : PlayerBase
{
    public override async Task Attack()
    {   
        isAttacking = true;
        vfx.GetComponent<BombGuyVFX>().currentState = BombGuyVFX.AbilityState.MAIN;
        vfx.GetComponent<BombGuyVFX>().host = this.gameObject;
        StartCoroutine(vfx.GetComponent<BombGuyVFX>().Attack(this.gameObject));
        while (isAttacking != false)
        {
            Debug.Log(gameObject.name + " " + "attacking");
            await Task.Yield();
        }
        await Move();
    }

    public override Task Move()
    {
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
        vfx = this.GetComponent<BombGuyVFX>();
        vfx.host = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
}
