using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public bool targetInRange = false;
    public bool targetOutOfRange = false;

    public int randomTarget;
    WeightedPriority runMethod;

    public bool oneTarget;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is angry.");
        // Stop turning randomly
        // Roar
        // Find aggressor using weighted prio system

        // Call weighted prio system
        runMethod = GameObject.FindGameObjectWithTag("Generator").GetComponent<WeightedPriority>();
        

        // Find the target returned
        if(oneTarget)
        {
            runMethod.GenerateRandomWeight();
            randomTarget = WeightedPriority.finalValue;
            oneTarget = false;
        }

        //Debug.Log("randomTarget == " + randomTarget);
        if(randomTarget==2)
        {
            //target is companion
            //find companion
        }
        else
        {
            //target is player
            //find player
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
