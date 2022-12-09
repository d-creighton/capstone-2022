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

    public bool delayCheck = false;
    Coroutine timeDelay;

    public override State RunCurrentState()
    {
        //delayCheck = false;
        /* if (flag)
        {
            Debug.Log("Palkia is angry.");
            flag = false;
        } */
        // Stop turning randomly
        // Roar
        
        //Debug.Log("Angry 1");

        // Find aggressor using weighted prio system

        // Call weighted prio system
        

        // Find the target returned
        if(oneTarget)
        {
            Debug.Log("Palkia is angry.");
            cry = GetComponent<AudioSource>();
            cry.Play();

            runMethod = generator.GetComponent<WeightedPriority>();

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

                //timeDelay = Timer.DelayActionRetriggerable(this, delayCheck, 3.0f, timeDelay);
                StartCoroutine(DelayCoroutine());
            }
            else
            {
                //target is player
                //find player
                target = GameObject.FindGameObjectWithTag("Player");
                fov.targetRef = target;

                //timeDelay = Timer.DelayActionRetriggerable(this, delayCheck, 3.0f, timeDelay);
                StartCoroutine(DelayCoroutine());
            }

            oneTarget = false;
            //Debug.Log("oneTarget f");
        }
        //Debug.Log(delayCheck);
        if (delayCheck)
        {
            if (targetInRange)
            {
                attackState.canDelay = true;
                attackState.hasAttacked = false;
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

    private IEnumerator DelayCoroutine()
    {
        float delay = 3.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        //while (true)
        //{
            yield return wait;
            delayCheck = true;
            //Debug.Log("angry delay");
        //}
    }
}
