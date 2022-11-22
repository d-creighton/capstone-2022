using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int maxHP;
    public int currentHP;

    public BarFunctionality healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxSliderValue(maxHP);
        healthBar.SetLabel(currentHP, maxHP);
    }

    // Call if projectile hits
    public bool TakeDamage(int damageTaken)
    {
        // Take damage
        currentHP -= damageTaken;

        // Check if this unit has died
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
