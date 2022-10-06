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
    //WeightedPriority canExecute;
    WeightedPriority runMethod;

    public override State RunCurrentState()
    {
        Debug.Log("Palkia is angry.");
        // Stop turning randomly
        // Roar
        // Find aggressor using weighted prio system

        //generateCheck = true;

        // Call weighted prio system
        runMethod = GameObject.FindGameObjectWithTag("Generator").GetComponent<WeightedPriority>();
        //canExecute = GameObject.FindGameObjectWithTag("Generator").GetComponent<WeightedPriority>();
        //WeightedPriority.canExecute = true;
        runMethod.GenerateRandomWeight();

        // Find the target returned
        randomTarget = WeightedPriority.finalValue;
        Debug.Log("randomTarget == " + randomTarget);
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
