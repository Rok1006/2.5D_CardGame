using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculation
{

    public static float CalculateDamage(Stat host, Stat guest)
    {
        // Perform calculations to determine the final damage

        float damage;
        float crit = Random.Range(0f, 1f);
        bool isCrit = crit < host.criticalChance;
        float damageMod = isCrit ? host.criticalMultiplier : 1f;

        damage = host.baseDamage * damageMod * ElementalMultiplier(host.element.ToString(), guest.element.ToString());

        // Apply any additional modifiers or formulas here
        // For example, you could add critical hit chances, elemental bonuses, etc.
        Debug.Log(damage);
        return damage;
    }

    private static float ElementalMultiplier(string host, string guest)
    {
        float elementalMultiplier = 1f;

        switch (host)
        {
            case "Fire":
                if(guest == "Water")
                {
                    return 0.5f;
                }
                break;
            case "Water":
                if (guest == "Earth")
                {
                    return 0.5f;
                }
                break;
            case "Wind":
                if (guest == "Fire")
                {
                    return 0.5f;
                }
                break;
            case "Earth":
                if (guest == "Wind")
                {
                    return 0.5f;
                }
                break;

        }

        return elementalMultiplier;

    }

}
