using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    public UnityEvent<DamageFeedback> onEnemyAttack;
    public UnityEvent<EnemyBase> onEnemyDeath;
    public UnityEvent<EnemyBase> onEnemySpawn;
    public UnityEvent onCardUsed;
    public UnityEvent OnTurnFinished;
    public UnityEvent OnTurnStart;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
           
        }
    }
}