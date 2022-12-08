using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AngryState angryState;
    public Attack bossAttack;
    public bool hasAttacked = false;

    public bool canAtack = true;

    //public GameObject targetToAttack = angryState.target;
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
        
        // Attack the chosen target
        if (canAtack)
        {
            targetToAttack = angryState.target;
            Debug.Log("1");
            bossAttack.targetRef = targetToAttack;
            Debug.Log("2");
            bossAttack.WeakAttack();
            Debug.Log("3");
            canAtack = false;
            Debug.Log("4");
        }

        // set hasAttacked to true after attack
        hasAttacked = true;
        Debug.Log("5");

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
