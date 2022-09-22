using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
