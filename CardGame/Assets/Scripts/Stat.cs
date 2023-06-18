using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stat")]
public class Stat : ScriptableObject
{
    public enum Element
    {
        Fire,
        Earth,
        Wind,
        Water
    }

    public Element element;
    public float baseDamage;
    public float defense;
    public float criticalChance;
    public float criticalMultiplier;

}
