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
        healthBar.SetLabel(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //damage code
    }

    void TakeDamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
        healthBar.SetLabel(currentHealth, maxHealth);
    }
}
