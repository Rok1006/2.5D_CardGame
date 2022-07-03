using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoard : MonoBehaviour
{
    public bool isOccupied;
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
            Debug.Log("touched");
            GameManager.ready++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (GameManager.gameState == 0 && collision.gameObject.CompareTag("Player"))
        {
            GameManager.ready--;
        }
    }
 

}
