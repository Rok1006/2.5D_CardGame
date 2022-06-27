using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Interaction with Drag and Drop Variables
    [HideInInspector] public bool isBeingDragged;
    [HideInInspector] public bool isOnPlayerBoard;
    [HideInInspector] public GameObject currentPlayerBoard;
    [HideInInspector] public Vector3 currentPos;



    //Player Stats Variables
    public int health;
    public int attack;
    public int defense;


    // Interaction between Player Variables with SphereCast
    public float sphereRadius;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;

    //General
    public GameObject gameManager;
    void Start()
    {
        currentPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingDragged)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) * 100, out hit);

            if (hit.collider.CompareTag("PlayerBoard"))
            {
                currentPlayerBoard = hit.collider.gameObject;
                isOnPlayerBoard = true;

            }
            else
            {
                currentPlayerBoard = null;
                isOnPlayerBoard = false;

            }

        }

    


        /******************************* Game State 1*********************************************************/
        if (GameManager.gameState == 1)
        {
            if (isBeingDragged)
            {
                //todo
            }
        }
    }
}
