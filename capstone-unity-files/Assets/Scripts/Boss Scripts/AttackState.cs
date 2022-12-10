using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackDelay attackDelay;

    public AngryState angryState;

    public Attack bossAttack;

    public bool hasAttacked = false;

    public bool canAttack;

    public GameObject targetToAttack;

    //bool flag = true;
    public bool canDelay = false;

    Coroutine timeDelay;

    public override State RunCurrentState()
    {
        /* if (flag)
        {
            Debug.Log("Palkia is attacking the target.");
            flag = false;
        } */
        if (canDelay)
        {
            Debug.Log("Palkia is attacking the target.");
            Debug.Log (hasAttacked);

            //timeDelay = Timer.DelayActionRetriggerable(this, canAttack, 3.0f, timeDelay);
            StartCoroutine(DelayCoroutine());
            canDelay = false;
        }

        // Attack the chosen target
        if (canAttack)
        {
            targetToAttack = angryState.target;
            bossAttack.targetRef = targetToAttack;
            bossAttack.WeakAttack();
            hasAttacked = true;
            canAttack = false;
        }

        if (hasAttacked)
        {
            hasAttacked = false;
            angryState.oneTarget = true;
            return angryState;
        }
        else
        {
            return this;
        }
    }

    private IEnumerator DelayCoroutine()
    {
        float delay = 1.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        //while (true)
        //{
        yield return wait;
        canAttack = true;
        //Debug.Log("attack delay");
        //}
    }
}
