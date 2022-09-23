using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public bool targetInRange;
    public bool targetOutOfRange;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is angry.");
        // Roar
        // Find aggressor using weighted prio system

        if (targetInRange)
        {
            return attackState;
        }
        else if (targetOutOfRange)
        {
            return spinState;
        }
        else
        {
            return this;
        }
    }
}
