using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{
   
    public GameObject whatIsOnThisBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(GameManager.gameState == 0 && collision.gameObject.CompareTag("Player"))
        {
            
            GameManager.ready++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (GameManager.gameState == 0 && collision.gameObject.CompareTag("Player"))
        {
            GameManager.ready--;
            whatIsOnThisBoard = null;   
        }
        if (GameManager.gameState == 2 && collision.gameObject.CompareTag("Player"))
        {
           
            whatIsOnThisBoard = null;
        }

    }
    private void OnTriggerStay(Collider collision)
    {
        if (GameManager.gameState == 0 && collision.gameObject.CompareTag("Player"))
        {
           
            whatIsOnThisBoard = collision.gameObject;
        }
        if (GameManager.gameState == 2 && collision.gameObject.CompareTag("Player"))
        {

            whatIsOnThisBoard = collision.gameObject;
        }
    }


}
