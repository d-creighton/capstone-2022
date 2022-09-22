using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public AngryState angryState;
    public bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        if (canSeeThePlayer)
        {
            return angryState;
        }
        else
        {
            return this;
        }
        
    }
}
