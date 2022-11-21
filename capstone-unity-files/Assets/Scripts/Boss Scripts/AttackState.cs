using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AngryState angryState;
    public bool hasAttacked = false;

    public override State RunCurrentState()
    {
        angryState.oneTarget = true;

        //Debug.Log("Palkia is attacking the target.");
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
