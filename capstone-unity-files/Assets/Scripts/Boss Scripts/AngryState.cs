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
    public GameObject generator;
    public WeightedPriority runMethod;

    public bool oneTarget = true;
    public GameObject target;

    public AudioSource cry;

    bool flag = true;

    public override State RunCurrentState()
    {

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
        //Debug.Log("Angry 2");
        //oneTarget = true;

        // Find the target returned
        if(oneTarget)
        {
            runMethod.GenerateRandomWeight();
            //Debug.Log("Angry 3");
            randomTarget = WeightedPriority.finalValue;
            //Debug.Log("Angry 4");
            oneTarget = false;
            //Debug.Log("Angry 5");
        }

        //Debug.Log("randomTarget == " + randomTarget);
        if(randomTarget==2)
        {
            //target is companion
            //find companion
            Debug.Log("target AI set in angry");
            target = GameObject.FindGameObjectWithTag("Friendly");

            //check if in range
            Debug.Log("checking if in range");
            if(fov.canSeeTarget)
            {
                Debug.Log("true");
                targetInRange = true;
            }
            else
            {
                Debug.Log("false");
                targetInRange = false;
            }
        }
        else
        {
            //target is player
            //find player
            Debug.Log("target player set in angry");
            target = GameObject.FindGameObjectWithTag("Player");

            //check if in range
            Debug.Log("checking if in range");
            if(fov.canSeeTarget)
            {
                Debug.Log("true");
                targetInRange = true;
            }
            else
            {
                Debug.Log("false");
                targetInRange = false;
            }
        }


        if (targetInRange)
        {
            attackState.canAtack = true;
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
