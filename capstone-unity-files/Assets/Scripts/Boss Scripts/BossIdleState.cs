using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : State
{
    public AngryState angryState;
    public bool wasAttacked;

    public override State RunCurrentState()
    {
        // turn randomly
        
        Debug.Log("Palkia is idle.");
        if (wasAttacked)
        {
            return angryState;
        }
        else
        {
            return this;
        }
        
    }
}
