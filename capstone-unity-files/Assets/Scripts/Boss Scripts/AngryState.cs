using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public bool targetInRange = false;
    //public bool targetOutOfRange = false;

    public int randomTarget;
    WeightedPriority runMethod;

    public bool oneTarget;
    GameObject target;

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
            GameObject target = GameObject.FindGameObjectWithTag("Friendly");

            //check if in range
        }
        else
        {
            //target is player
            //find player
            GameObject target = GameObject.FindGameObjectWithTag("Player");

            //check if in range
        }


        if (targetInRange)
        {
            return attackState;
        }
        else if (!targetInRange)
        {
            return spinState;
        }
        else
        {
            return this;
        }
    }
}
