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
        // get target from AngryState
        // want to find target each time it changes
        if (gameObject.CompareTag("Friendly"))
        {
            // companion will always target boss
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
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        // add anything that overlaps to the array
        Collider[] rangeChecks =
            Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            for (int i = 0; i < rangeChecks.Length; i++)
            {
                if (rangeChecks[i] == targetRef)
                {
                    canSeeTarget = true;
                    targetRef = rangeChecks[i].gameObject;
                    break;
                }
            }

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
                        canSeeTarget = true;
                        confirmTarget = true;
                    }
                    else
                    {
                        canSeeTarget = false;
                        confirmTarget = false;
                    }
                }
                else
                {
                    canSeeTarget = false;
                    confirmTarget = false;
                }
            }
        }
        else if (canSeeTarget)
        {
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
