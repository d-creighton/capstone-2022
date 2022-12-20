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

        // Face in direction of boss
        faceBoss.LookAtTarget(fov.targetRef);

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
