using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : State
{
    public AttackState attackState;
    public bool targetFound = false;

    public override State RunCurrentState()
    {
        //Debug.Log("Palkia is aiming at the target.");
        // Face target found in AngryState
        // turn to that target until FieldOfView.canSeeTarget == true

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
