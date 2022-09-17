using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject whatIsOnBoard;
    public int rowNum;
    
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position , transform.up , out hit)){

            if(hit.collider.gameObject.tag == "EnemyCard" || hit.collider.gameObject.tag == "ItemCard")
            {
                whatIsOnBoard = hit.collider.gameObject;
            }
            
        }
        else
        {
            whatIsOnBoard = null;
        }
        
        if(whatIsOnBoard!=null){
            whatIsOnBoard.GetComponent<CardLayers>().ChangeLayers(rowNum);
        }
    }
}
