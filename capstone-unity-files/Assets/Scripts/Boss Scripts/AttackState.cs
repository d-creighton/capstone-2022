using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackDelay attackDelay;
    public AngryState angryState;
    public Attack bossAttack;
    public bool hasAttacked = false;

    public bool canAtack;

    public GameObject targetToAttack;

    bool flag = true;

    public override State RunCurrentState()
    {
        angryState.oneTarget = true;

        if (flag)
        {
            Debug.Log("Palkia is attacking the target.");
            flag = false;
        }
        
        if (!attackDelay.initiateDelay)
        {
            canAtack = true;
        } 
        
        // Attack the chosen target
        if (canAtack)
        {
            targetToAttack = angryState.target;
            bossAttack.targetRef = targetToAttack;
            bossAttack.WeakAttack();
            hasAttacked = true;
            canAtack = false;
        }

        if (hasAttacked)
        {
            return angryState;
        }
        else
        {
            return this;
        }
    }
}
