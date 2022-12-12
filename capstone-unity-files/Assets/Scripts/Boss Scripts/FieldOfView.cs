using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;

    [Range(0, 360)]
    public float angle;

    public GameObject targetRef = null;

    public LayerMask targetMask;

    public LayerMask obstructionMask;

    public bool canSeeTarget;

    public bool confirmTarget;

    public AngryState angryState;

    public SeekingState seekingState;

    private void Start()
    {
        //get target from AngryState
        //targetRef = GameObject.FindGameObjectWithTag("");
        //want to find target each time it changes
        if (gameObject.CompareTag("Friendly"))
        {
            targetRef = GameObject.FindWithTag("Enemy");
            seekingState =
                GameObject
                    .FindWithTag("AI Seeking State")
                    .GetComponent<SeekingState>();

            targetMask = LayerMask.GetMask("Enemies");
            obstructionMask = LayerMask.GetMask("Obstruction");

            radius = 70;
            angle = 1;
        }

        //Debug.Log("Starting Coroutine");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;

            //targetRef = angryState.target;
            //Debug.Log("Checking FOV");
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        //GameObject targetRef;
        //targetRef = angryState.target;
        // add anything that overlaps to the array
        Collider[] rangeChecks =
            Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            //Debug.Log("if 1");
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                //Debug.Log("for 1");
                if (rangeChecks[i] == targetRef)
                {
                    //Debug.Log("if 2");
                    canSeeTarget = true;
                    targetRef = rangeChecks[i].gameObject;
                    break;
                }
            }

            //Debug.Log("Transform target");
            if (targetRef != null)
            {
                Transform target = targetRef.transform;
                Vector3 directionToTarget =
                    (target.position - transform.position).normalized;

                if (
                    Vector3.Angle(transform.forward, directionToTarget) <
                    angle / 2
                )
                {
                    //Debug.Log("if Vector3");
                    float distanceToTarget =
                        Vector3.Distance(transform.position, target.position);

                    if (
                        !Physics
                            .Raycast(transform.position,
                            directionToTarget,
                            distanceToTarget,
                            obstructionMask)
                    )
                    {
                        //Debug.Log("if !Physics");
                        canSeeTarget = true;
                        confirmTarget = true;
                    }
                    else
                    {
                        //Debug.Log("if Physics");
                        canSeeTarget = false;
                        confirmTarget = false;
                    }
                }
                else
                {
                    //Debug.Log("if !Vector3");
                    canSeeTarget = false;
                    confirmTarget = false;
                }
            }
        }
        else if (canSeeTarget)
        {
            //Debug.Log("if canSeeTarget");
            canSeeTarget = false;
            confirmTarget = false;
        }

        if (gameObject.CompareTag("Friendly"))
        {
            seekingState.bossFound = confirmTarget;
        }
        else
        {
            angryState.targetInRange = confirmTarget;
        }
    }
}
