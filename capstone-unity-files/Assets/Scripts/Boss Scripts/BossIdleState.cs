using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : State
{
    Rigidbody bossRigidBody;            // This object's Rigidbody
    public AngryState angryState;       // The next state after this state
    public bool wasAttacked = false;    // Determine if the next state should be triggered

    void Start() 
    {
        // Get Rigidbody
        bossRigidBody = GetComponent<Rigidbody>();
    }

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

    // detect tag of actual "attack" and move to next state
    private void OnCollisionEnter(Collision collision) 
    {
        // laser = entity of the attack itself
        GameObject laser = collision.gameObject;
        if (laser.CompareTag("Laser"))
        {
            wasAttacked = true;
        }
    }
}
