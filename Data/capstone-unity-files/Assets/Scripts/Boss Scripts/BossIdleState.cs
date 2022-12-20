using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : State
{
    public AngryState angryState; // The next state after this state

    public bool wasAttacked = false; // Determine if the next state should be triggered

    public override State RunCurrentState()
    {
        angryState.oneTarget = true;

        if (wasAttacked)
        {
            return angryState;
        }
        else
        {
            return this;
        }
    }
}
