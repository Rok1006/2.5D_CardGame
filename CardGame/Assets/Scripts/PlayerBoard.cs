using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{
    //1 passive1 2 passive2 3 attack1 4 attack2
    public int id;
 
    public GameObject whatIsOnThisBoard;
   
    // Start is called before the first frame update
  

    // Update is called once per frame


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
