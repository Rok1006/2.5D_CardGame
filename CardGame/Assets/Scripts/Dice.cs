using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        SetInitialState();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckObjectHasStopped() == true)
        {

        }
    }

    public bool CheckObjectHasStopped()
    {
        if (rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero)
        {
            return true;
        }
        else return false;
    }

    private void SetInitialState()
    {
        int x = Random.Range(0, 360);
        int y = Random.Range(0, 360);
        int z = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(x, y, z);

        x = Random.Range(0, 25);
        y = Random.Range(0, 25);
        z = Random.Range(0, 25);
        Vector3 force = new Vector3(x, y, z);

        x = Random.Range(0, 50);
        y = Random.Range(0, 50);
        z = Random.Range(0, 50);
        Vector3 torque = new Vector3(x, y, z);

        transform.rotation = rotation;
        rb.velocity = force;
        rb.maxAngularVelocity = 1000;
        rb.AddTorque(torque, ForceMode.VelocityChange);


    }
}