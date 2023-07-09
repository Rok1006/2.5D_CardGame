using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AttackPattern : ScriptableObject
{
    public bool isEnemy;
    public bool isPlayer;
    public int amount;

    public abstract GameObject GetElement(int startX, int startY, GameObject[,] grid);
}

