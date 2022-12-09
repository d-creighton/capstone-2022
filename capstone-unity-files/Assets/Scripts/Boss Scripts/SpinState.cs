using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : State
{
    public AttackState attackState;
    public AngryState angryState;
    public LookAt lookAt;
    public bool targetFound = false;

    public GameObject targetToAim;
    public FieldOfView fov;

    bool flag = true;

    public override State RunCurrentState()
    {

        if (flag)
        {
            Debug.Log("Palkia is aiming at the target.");
            flag = false;
        }        
        
        // Face target found in AngryState
        //targetToAim = angryState.target;
        // turn to that target until FieldOfView.canSeeTarget == true
        while (!fov.canSeeTarget)
        {
            lookAt.LookAtTarget();
        }

        if (targetFound)
        {
            targetFound = false;
            attackState.canDelay = true;
            attackState.hasAttacked = false;
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
