using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public SpinState spinState;
    public AttackState attackState;
    public FieldOfView fov;
    public bool targetInRange;

    public int randomTarget;
    public GameObject generator;
    public WeightedPriority runMethod;

    public bool oneTarget= true;
    public GameObject target = null;

    public AudioSource cry;

    bool flag = true;
    public bool delayCheck;

    public override State RunCurrentState()
    {
        //delayCheck = false;
        if (flag)
        {
            Debug.Log("Palkia is angry.");
            flag = false;
        }
        // Stop turning randomly
        // Roar
        cry = GetComponent<AudioSource>();
        cry.Play();
        //Debug.Log("Angry 1");

        // Find aggressor using weighted prio system

        // Call weighted prio system
        runMethod = generator.GetComponent<WeightedPriority>();

        // Find the target returned
        if(oneTarget)
        {
            runMethod.GenerateRandomWeight();
            randomTarget = WeightedPriority.finalValue;

            if(randomTarget==2)
            {
                //target is companion
                //find companion
                target = GameObject.FindGameObjectWithTag("Friendly");
                //check if AI is still alive
                if (target == null)
                {
                    target = GameObject.FindGameObjectWithTag("Player");
                }
                fov.targetRef = target;

            }
            else
            {
                //target is player
                //find player
                target = GameObject.FindGameObjectWithTag("Player");
                fov.targetRef = target;

            }

            oneTarget = false;
        }

        if (!attackDelay.initiateDelay)
        {
            if (targetInRange)
            {
                attackState.canAttack = true;
                return attackState;
            }
            else //if (!targetInRange)
            {
                return spinState;
            }
        }
        else
        {
            return this;
        }
    }
}
