using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Palkia is aiming at the target.");
        return this;
    }
}
