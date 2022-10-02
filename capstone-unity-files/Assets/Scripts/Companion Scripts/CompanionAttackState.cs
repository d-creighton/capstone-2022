using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAttackState : State
{
    public CompanionIdleState idleState;
    public bool hasAttacked;

    public override State RunCurrentState()
    {
        // Cry semi-randomly
        // Attack boss

        Debug.Log("Torterra is attacking Palkia.");
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
