using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public abstract class EnemyBase : MonoBehaviour
{
    public delegate void onMoveComplete();
    public event onMoveComplete moveComplete;
    public abstract Task Move();
    public abstract Task Attack();

    public abstract void MoveComplete();

    

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
