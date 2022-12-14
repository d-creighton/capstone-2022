using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionIdleState : State
{
    public SeekingState seekingState;

    public bool commandReceived = false;

    public CompanionMovement movement;

    public Transform rootTransform;

    public GameObject rootObject;

    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;
        movement = rootObject.GetComponent<CompanionMovement>();
    }

    public override State RunCurrentState()
    {
        // Await commands from player
        //Debug.Log("Torterra is awaiting commands.");
        movement.canFollow = true;

        if (commandReceived)
        {
            movement.canFollow = false;
            commandReceived = false;
            return seekingState;
        }
        else
        {
            return this;
        }
    }
}
