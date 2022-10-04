using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingState : State
{
    public CompanionAttackState atackState;
    public bool bossFound;

    public override State RunCurrentState()
    {
        // Locate boss

        Debug.Log("Torterra is seeking Palkia.");
        if (bossFound)
        {
            return atackState;
        }
        else
        {
            return this;
        }
    }
}
