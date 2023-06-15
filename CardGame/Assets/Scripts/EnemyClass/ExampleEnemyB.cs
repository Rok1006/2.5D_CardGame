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

    public override List<GameObject> EvaluateDestination()
    {
        var destination = this.movementPattern[0].Movement(this.grid.row, this.grid.column);

      

        return destination;
    }

    public override async Task Move()
    {
        EvaluateDestination();
        await Task.Delay(3000);
        Debug.Log("moved");
        
    }

    public override void MoveComplete()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
