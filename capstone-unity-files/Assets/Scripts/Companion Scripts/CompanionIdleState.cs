using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionIdleState : State
{
    public SeekingState seekingState;
    public bool commandReceived;

    public override State RunCurrentState()
    {
        // Await commands from player
        // Wander slightly
        // Cry semi-randomly
        // Dodge boss attacks
        // Execute small auto-attacks

        Debug.Log("Torterra is awaiting commands.");
        if (commandReceived)
        {
            return seekingState;
        }
        else
        {
            return this;
        }
    }
}
