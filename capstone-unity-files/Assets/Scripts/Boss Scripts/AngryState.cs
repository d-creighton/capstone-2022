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

    public bool oneTarget = true;

    public GameObject target = null;

    public AudioSource cry;

    public bool delayCheck = false;

    Coroutine timeDelay;

    public override State RunCurrentState()
    {
        // Find aggressor using weighted prio system
        // Call weighted prio system
        // Find the target returned
        if (oneTarget)
        {
            runMethod = generator.GetComponent<WeightedPriority>();
            runMethod.GenerateRandomWeight();
            randomTarget = WeightedPriority.finalValue;

            Debug.Log("Palkia is angry.");
            cry = GetComponent<AudioSource>();
            cry.Play();

            StartCoroutine(DelayCoroutine());
            oneTarget = false;
        }

        if (randomTarget == 2)
        {
            //target is companion
            //find companion
            target = GameObject.FindGameObjectWithTag("Friendly");

            //Debug.Log (target);
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

        //Debug.Log(delayCheck);
        if (delayCheck)
        {
            delayCheck = false;
            if (targetInRange)
            {
                attackState.canDelay = true;
                return attackState;
            }
            else
            {
                return spinState;
            }
        }
        else
        {
            return this;
        }
    }

    // Time delay before moving into next state
    private IEnumerator DelayCoroutine()
    {
        float delay = 5.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;
        delayCheck = true;
    }
}
