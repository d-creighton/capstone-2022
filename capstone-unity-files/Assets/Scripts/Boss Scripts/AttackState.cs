using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AngryState angryState;
    public bool hasAttacked;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is attacking the target.");
        hasAttacked = false;
        // Attack the chosen target
        // set hasAttacked to true after attack

        if (hasAttacked)
        {
            return angryState;
        }
        else
        {
            return this;
        }
    }
}
