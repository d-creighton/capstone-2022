using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionIdleState : State
{
    public SeekingState seekingState;
    public bool commandReceived = false;

    public override State RunCurrentState()
    {
        // Await commands from player
        // Wander slightly
        // Cry semi-randomly
            // enumerate seconds
            // random number of seconds
            // if just cried
            // wait at least x number of seconds
            // repeat

        // Dodge boss attacks
        // Execute small auto-attacks

        Debug.Log("Torterra is awaiting commands.");
        if (commandReceived)
        {
            commandReceived = false;
            return seekingState;
        }
        else
        {
            return this;
        }
    }
}
