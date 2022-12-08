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

    public GameObject CompanionPrefab;
    public BossIdleState idleState;

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
        idleState.wasAttacked = true;

        // Take damage
        currentHP -= damageTaken;
        healthBar.SetValue(currentHP);
        healthBar.SetLabel(currentHP, maxHP);

        // Check if this unit has died
        if(currentHP <= 0)
        {
            currentHP = 0;
            healthBar.SetValue(currentHP);
            healthBar.SetLabel(currentHP, maxHP);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int potion)
    {
        currentHP += potion;
        if(currentHP > maxHP) { currentHP = maxHP; }

        healthBar.SetValue(currentHP);
        healthBar.SetLabel(currentHP, maxHP);
    }

    public void Revive()
    {
        GameObject torterra = Instantiate(CompanionPrefab, new Vector3(10,0,10), Quaternion.identity);
    }
}
