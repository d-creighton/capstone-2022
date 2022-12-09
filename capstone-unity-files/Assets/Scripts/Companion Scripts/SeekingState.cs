using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingState : State
{
    public CompanionAttackState atackState;
    public bool bossFound;

    //public GameObject boss;
    public LookAt faceBoss;

    public override State RunCurrentState()
    {
        // Locate boss
        //boss = GameObject.FindWithTag("Enemy");
        //if (boss == null) return;

        //Rigidbody bossRigidbody = boss.GetComponent<Rigidbody>();
        //Transform bossTransform = boss.GetComponent<Transform>();

        // Face in direction of boss
        //bossFound = faceBoss.LookAtTarget();

        //bossFound = true;

        //Debug.Log("Torterra is seeking Palkia.");
        if (bossFound)
        {
            bossFound = false;
            return atackState;
        }
        else
        {
            return this;
        }
    }
}
