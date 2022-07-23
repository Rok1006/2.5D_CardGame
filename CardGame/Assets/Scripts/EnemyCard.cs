using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCard : MonoBehaviour
{
    public ScriptableObject Stats;
    public float health;
    public float attackPoint;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void moveEnemyCardDown()
    {

        this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, 0, 2.5f);
        /*
        transform.DOMove(this.gameObject.transform.position - new Vector3(0, 0, 2.5f), 0.7f).OnComplete(() => {
            isMoving = false;
        });
        */
        isMoving = false;

    }

    public void Attack()
    {
        Debug.Log("attacking");
    }
}
