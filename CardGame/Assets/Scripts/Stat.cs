using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stat")]
public class Stat : ScriptableObject
{
    [Header("Initialization")]
    public Sprite cardImage;
    public string name;
    public int minHp;
    public int maxHp;
    public int minAttack;
    public int maxAttack;

    [Header("Stat")]
    public float baseDamage;
    public float defense;
    public float criticalChance;
    public float criticalMultiplier;
    public enum Element
    {
        Fire,
        Earth,
        Wind,
        Water
    }
    public Element element;
    

}
