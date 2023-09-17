using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldEffect
{
    EnemyBase Enemy { get; }
    public void OnStatusEffect();

    public void DuringStatusEffect();
    public void ExitStatusEffect();
}
