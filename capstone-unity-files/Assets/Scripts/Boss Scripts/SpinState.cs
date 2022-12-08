using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : State
{
    public AttackState attackState;
    public bool targetFound = false;

    //public FieldOfView fov;

    bool flag = true;

    public override State RunCurrentState()
    {

        if (flag)
        {
            Debug.Log("Palkia is aiming at the target.");
            flag = false;
        }        
        
        // Face target found in AngryState
        // turn to that target until FieldOfView.canSeeTarget == true
        //if (fov.canSeeTarget)
        //{
        //    targetFound = true;
        //}


        if (targetFound)
        {
            targetFound = false;
            attackState.canAtack = true;
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
