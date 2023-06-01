using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ExampleEnemyB : EnemyBase
{
    public override Task Attack()
    {
        throw new System.NotImplementedException();
    }

    public override async Task Move()
    {
        
        await Task.Delay(3000);
        Debug.Log("moved");
        
    }

    public override void MoveComplete()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
