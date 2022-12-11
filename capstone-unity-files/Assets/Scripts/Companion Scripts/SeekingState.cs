using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingState : State
{
    public CompanionAttackState atackState;

    public bool bossFound;

    public GameObject boss;

    public LookAt faceBoss;

    public FieldOfView fov;

    public GameObject rootObject;

    public Transform rootTransform;

    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;
        fov = rootObject.GetComponent<FieldOfView>();
    }

    public override State RunCurrentState()
    {
        // Locate boss
        boss = GameObject.FindWithTag("Enemy");
        fov.targetRef = boss;

        //if (boss == null) return;
        //Rigidbody bossRigidbody = boss.GetComponent<Rigidbody>();
        //Transform bossTransform = boss.GetComponent<Transform>();
        // Face in direction of boss
        //bossFound = faceBoss.LookAtTarget();
        faceBoss.LookAtTarget(fov.targetRef);

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
