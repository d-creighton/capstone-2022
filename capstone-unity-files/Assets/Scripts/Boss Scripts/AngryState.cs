using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public bool targetInRange = false;
    public bool targetOutOfRange = false;

    public bool randomTarget;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is angry.");
        // Stop turning randomly
        // Roar
        // Find aggressor using weighted prio system

        // Call weighted prio system
        int WeightedPriority.GenerateRandomWeight();

        // Find the target returned
        randomTarget = WeightedPriority.finalValue;
        if(randomTarget)
        {
            //target is player
            //find player
        }
        else
        {
            //target is companion
            //find companion
        }


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
