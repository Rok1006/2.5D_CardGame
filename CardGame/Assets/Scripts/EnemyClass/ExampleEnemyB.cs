using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using DG.Tweening;

public class ExampleEnemyB : EnemyBase
{
    public override async Task Attack()
    {
        var options = this.attackPattern[0].GetElement(this.grid.row , this.grid.column, GridManagerPlus.instance.grid);
        if (options != null)
        {
            Instantiate(indicator, options.transform.position, indicator.transform.rotation);
            await Task.Delay(1000);

        }
    }

    public override List<Vector3> EvaluateDestination()
    {
        var destination = this.movementPattern[0].Movement(this.grid.row, this.grid.column,this.gameObject);


        Debug.Log(destination[0]);
        return destination;
    }

    public override async Task Move()
    {
        var options = EvaluateDestination();
        if (options.Count != 0)
        {
            this.transform.DOMove(options[0], 0.3f).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                Debug.Log("moved");
            });
            await Task.Delay(1000);
            
        }
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
