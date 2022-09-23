using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : State
{
    public AttackState attackState;
    public bool targetFound;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is aiming at the target.");
        // Face target found in AngryState

        if (targetFound)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
