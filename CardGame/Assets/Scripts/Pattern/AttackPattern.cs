using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AttackPattern : ScriptableObject , IAttack
{
    public bool isEnemy;
    public bool isPlayer;
    public int amount;
    public bool multiple;
    public List<GameObject> options = new List<GameObject>();

    public abstract List<GameObject> GetElement(int startX, int startY, ref GameObject[,] grid);

    public abstract List<GameObject> DebugAttack(int startX, int startY, ref GameObject[,] grid);
    
}

