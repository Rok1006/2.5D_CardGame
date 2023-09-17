using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class FieldEffect : MonoBehaviour, IFieldEffect
{
    private EnemyBase enemy;
    public EnemyBase Enemy => enemy;

    public void DuringStatusEffect()
    {
        
    }

    public void ExitStatusEffect()
    {
        
    }

    public void OnStatusEffect()
    {
        enemy.health--;
    }
}
