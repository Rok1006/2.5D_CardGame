using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFeedback
{
    public  float intensity;
    public  float time;
    public AudioSource sound;
    public float damage;
    public Vector3 position;

    public DamageFeedback(Vector3 position, float damage)
    {
        Config(position, damage);
    }


    public void Config(Vector3 position, float damage)
    {
        intensity = 5f;
        time = 1f;
        this.position = position;
        this.damage = damage;

    }
    
}
