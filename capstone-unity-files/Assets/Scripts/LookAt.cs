using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //public GameObject target;
    //public bool hasTurned = false;
    public float speed = 0.25f;

    public GameObject rootObject;

    public Transform rootTransform;

    public FieldOfView fov;

    public SpinState spinState;

    public SeekingState seekingState;

    // Start is called before the first frame update
    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;

        //rootTransform = rootObject.GetComponent<Transform>();
        if (rootObject.CompareTag("Friendly"))
        {
            fov = rootObject.GetComponent<FieldOfView>();
            seekingState =
                GameObject
                    .FindWithTag("AI Seeking State")
                    .GetComponent<SeekingState>();
        } //if (rootObject.CompareTag("Enemy"))
        else
        {
            fov = rootObject.GetComponent<FieldOfView>();
            spinState =
                GameObject
                    .FindWithTag("Boss Spin State")
                    .GetComponent<SpinState>();
        }
    }

    public void LookAtTarget(GameObject target)
    {
        //GameObject target = fov.targetRef;
        Transform targetTransform = target.GetComponent<Transform>();

        Vector3 direction = targetTransform.position - rootTransform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        //rootTransform.rotation = rotation;
        rootTransform.rotation =
            Quaternion
                .Lerp(rootTransform.rotation, rotation, speed * Time.deltaTime);

        if (spinState != null && fov.canSeeTarget)
        {
            rootTransform.rotation =
                Quaternion
                    .Lerp(rootTransform.rotation,
                    rotation,
                    speed * Time.deltaTime);
            spinState.targetFound = true;
        }
        if (seekingState != null && fov.canSeeTarget)
        {
            rootTransform.rotation =
                Quaternion
                    .Lerp(rootTransform.rotation,
                    rotation,
                    speed * Time.deltaTime);
            seekingState.bossFound = true;
        }
    }
}
