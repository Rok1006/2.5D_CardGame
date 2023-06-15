using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : ScriptableObject
{
    public abstract List<GameObject> Movement(int row, int column);

}
