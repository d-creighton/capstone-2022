using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject targetRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeeTarget;

    public AngryState angryState;
    public State state;

    private void Start()
    {
        //get target from AngryState
        //targetRef = GameObject.FindGameObjectWithTag("");
        //want to find target each time it changes
        //targetRef = angryState.target;
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        //Debug.Log(angryState.targetLock);
        while (true)
        {
            Debug.Log("searching");
            if (angryState.targetLock)
            {
                Debug.Log("calling");
                yield return wait;
                targetRef = angryState.target;
                FieldOfViewCheck();
            }
        }
    }

    private void FieldOfViewCheck()
    {
        // add anything that overlaps to the array
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            for(int i=0; i<rangeChecks.Length; i++)
            {
                if(rangeChecks[i] == targetRef)
                {
                    canSeeTarget = true;
                    targetRef = rangeChecks[i].gameObject;
                    break;
                }

            }


                
                //if(rangeChecks[i] == targetRef)
                //{
                    Transform target = targetRef.transform;
                    Vector3 directionToTarget = (target.position - transform.position).normalized;

                    if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                    {
                        float distanceToTarget = Vector3.Distance(transform.position, target.position);

                        if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                        {
                            canSeeTarget = true;
                        }
                        else
                        {
                            canSeeTarget = false;
                        }
                    }
                    else
                    {
                        canSeeTarget = false;
                    }
                //}
                /*
                else if(canSeeTarget)
                {
                    canSeeTarget = false;
                }
                */
            //}
        }
        else if(canSeeTarget)
        {
            canSeeTarget = false;
        }

        /*if(rangeChecks.length != 0)
        {
            Transform target = rangeChecks[0].transform;
        }*/
    }
}
