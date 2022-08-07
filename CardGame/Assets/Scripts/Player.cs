using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Interaction with Drag and Drop Variables
    public bool isBeingDragged;
    public bool isOnPlayerBoard;
    public GameObject currentPlayerBoard;
    public Vector3 currentPos;



    //Player Stats Variables
    public int health;
    public int attack;
    public int defense;
    public int ability;


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
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1) * 100, out hit);

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

    public void AddHealth(int getHealth)
    {
        this.health = health + getHealth;
    }

    public void AddDefense(int getDefense)
    {
        this.defense = defense + getDefense;
    }

    public void AddAttack(int getAttack)
    {
        this.attack = attack + getAttack;
    }
}
