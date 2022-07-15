using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject whatIsOnBoard;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position , transform.up , out hit)){

            if(hit.collider.gameObject.tag == "EnemyCard")
            {
                whatIsOnBoard = hit.collider.gameObject;
            }
            
        }
        else
        {
            whatIsOnBoard = null;
        }

    }
}
