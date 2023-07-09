using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    GameObject GetElement(int startX, int startY, GameObject[,] grid);
}
