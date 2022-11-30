using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAttackState : State
{
    public CompanionIdleState idleState;
    //public bool canAttack;
    public bool hasAttacked;

    // value of 0-2, 0 means cannot attack, 1 is weak attack, 2 is strong attack
    public int attackStrength = 0;

    public Attack attackPool;
    public AudioSource pokemonCry;

    public override State RunCurrentState()
    {
        // Cry semi-randomly
        pokemonCry = GetComponent<AudioSource>();
        pokemonCry.Play();
        // Attack boss
        if(attackStrength == 1)
        {
            Debug.Log("Torterra is weakly attacking Palkia.");
            attackPool.WeakAttack();
            attackStrength = 0;
            hasAttacked = true;
        }
        else if(attackStrength == 2)
        {
            Debug.Log("Torterra is strongly attacking Palkia.");
            attackPool.StrongAttack();
            attackStrength = 0;
            hasAttacked = true;
        }

        Debug.Log("Torterra is preparing to attack Palkia.");
        if (hasAttacked)
        {
            return idleState;
        }
        else
        {
            return this;
        }
    }
}
