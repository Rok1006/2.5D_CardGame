using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBullet : MonoBehaviour
{
    public float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
