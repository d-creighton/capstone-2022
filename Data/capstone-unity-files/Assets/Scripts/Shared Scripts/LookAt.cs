using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
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

        if (rootObject.CompareTag("Friendly"))
        {
            fov = rootObject.GetComponent<FieldOfView>();
            seekingState =
                GameObject
                    .FindWithTag("AI Seeking State")
                    .GetComponent<SeekingState>();
        }
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
        // get references to target
        Transform targetTransform = target.GetComponent<Transform>();

        Vector3 direction = targetTransform.position - rootTransform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        // face direction of target
        rootTransform.rotation =
            Quaternion
                .Lerp(rootTransform.rotation, rotation, speed * Time.deltaTime);
        if (spinState != null && fov.canSeeTarget)
        {
            spinState.targetFound = true;
        }
        if (seekingState != null && fov.canSeeTarget)
        {
            seekingState.bossFound = true;
        }
    }
}
