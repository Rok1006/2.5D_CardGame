using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ExampleEnemyA : EnemyBase
{
    public GameObject projectile;
    public override Task Attack()
    {
        throw new System.NotImplementedException();
    }

    public override async Task Move()
    {
        var bullet =Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 30f, ForceMode.Impulse);
        while (bullet != null)
        {
            Debug.Log("ehh");
            await Task.Yield();
        }
        
        
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
