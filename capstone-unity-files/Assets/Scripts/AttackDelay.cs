using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDelay : MonoBehaviour
{
    public float secondsToWait = 5.0f;
    public float secondsSinceLast = 0.0f;
    public bool initiateDelay = false;

    public AttackState attackState;
    public AngryState angryState;

    void Update()
    {
        if (initiateDelay)
        {
        //secondsToWait = Random.Range(5.0f, 10.0f);
        secondsSinceLast += Time.deltaTime;

            if (secondsSinceLast >= secondsToWait)
            {
                //angryState.delayCheck = true;
                //attackState.canAtack = true;
                secondsSinceLast = 0;
                initiateDelay = false;
                //return;
            }
        }
    }
}
