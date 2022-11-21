using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public FieldOfView fov;
    public bool targetInRange;
    //public bool targetOutOfRange = false;

    public int randomTarget;
    WeightedPriority runMethod;

    public bool oneTarget;
    public GameObject target;

    public AudioSource cry;

    

    public override State RunCurrentState()
    {
        //Debug.Log("Palkia is angry.");
        // Stop turning randomly
        // Roar
        cry = GetComponent<AudioSource>();
        cry.Play();

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
            target = GameObject.FindGameObjectWithTag("Friendly");

            //check if in range
            if(fov.canSeeTarget)
            {
                targetInRange = true;
            }
            else
            {
                targetInRange = false;
            }
        }
        else
        {
            //target is player
            //find player
            target = GameObject.FindGameObjectWithTag("Player");

            //check if in range
            if(fov.canSeeTarget)
            {
                targetInRange = true;
            }
            else
            {
                targetInRange = false;
            }
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
