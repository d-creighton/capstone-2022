using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //public GameObject target;
    //public bool hasTurned = false;
    public float speed = 0.25f;

    public Transform thisObjectsTransform;
    public FieldOfView fov;

    public SpinState spinState;
    public SeekingState seekingState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LookAtTarget(GameObject target)
    {
        //GameObject target = fov.targetRef;
        Transform targetTransform = target.GetComponent<Transform>();

        Vector3 direction = targetTransform.position - thisObjectsTransform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = rotation;
        thisObjectsTransform.rotation = Quaternion.Lerp(thisObjectsTransform.rotation, rotation, speed * Time.deltaTime);
    
        if (fov != null && fov.canSeeTarget)
        {
            spinState.targetFound = true;
        }
        if (seekingState != null)
        {
            //seekingState.bossFound = true;
        }
    }
}
