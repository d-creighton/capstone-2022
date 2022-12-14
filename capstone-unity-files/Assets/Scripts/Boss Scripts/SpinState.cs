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

    //bool flag = true;
    public override State RunCurrentState()
    {
        /* if (flag)
        {
            Debug.Log("Palkia is aiming at the target.");
            flag = false;
        } */
        // Face target found in AngryState
        // turn to that target until FieldOfView.canSeeTarget == true
        lookAt.LookAtTarget(fov.targetRef);

        if (targetFound)
        {
            targetFound = false;
            attackState.canDelay = true;
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
