using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Overlord : EnemyBase
{
    public override Task Attack()
    {
        throw new System.NotImplementedException();
    }

    public override List<Vector3> EvaluateDestination()
    {
        throw new System.NotImplementedException();
    }

    public override Task Move()
    {
        throw new System.NotImplementedException();
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
