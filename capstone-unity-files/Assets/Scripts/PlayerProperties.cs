using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public BarFunctionality healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxSliderValue(maxHealth);
        //healthBar.SetLabel(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //damage code
    }

    public bool TakeDamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
        //healthBar.SetLabel(currentHealth, maxHealth);

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            healthBar.SetValue(currentHealth);
            //healthBar.SetLabel(currentHealth, maxHealth);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Heal(int potion)
    {
        currentHealth += potion;
        if(currentHealth > maxHealth) { currentHealth = maxHealth; }

        healthBar.SetValue(currentHealth);
        //healthBar.SetLabel(currentHealth, maxHealth);
    }
}
