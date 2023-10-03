using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    List<GameObject> GetElement(int startX, int startY, GameObject[,] grid);
  
}
