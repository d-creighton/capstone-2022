using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AngryState angryState;

    public Attack bossAttack;

    public bool hasAttacked = false;

    public bool canAttack;

    public GameObject targetToAttack;

    public bool canDelay = false;

    Coroutine timeDelay;

    public override State RunCurrentState()
    {
        if (canDelay)
        {
            //Debug.Log("Palkia is attacking the target.");
            //Debug.Log (hasAttacked);
            StartCoroutine(DelayCoroutine());
            canDelay = false;
        }

        // Attack the chosen target
        if (canAttack)
        {
            targetToAttack = angryState.target;

            //Debug.Log (targetToAttack);
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

    // Time delay before attacking
    private IEnumerator DelayCoroutine()
    {
        float delay = 1.0f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        yield return wait;
        canAttack = true;
    }
}
