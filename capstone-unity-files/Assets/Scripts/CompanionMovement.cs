using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    //public Transform transform; // This object's transform
    public float distancePerSecond = 10.0f; // Speed of this object

    public bool followPlayer; // Determine if player is close enough to follow

    public bool canFollow; // Determine if companion can move in current state

    public LookAt lookAt;

    // Start is called before the first frame update
    void Start()
    {
        lookAt =
            GameObject.FindWithTag("AI Seeking State").GetComponent<LookAt>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFollow)
        {
            if (followPlayer)
            {
                // Get reference to player
                GameObject player = GameObject.FindWithTag("Player");
                Transform playerTransform = player.GetComponent<Transform>();

                // Face player
                lookAt.LookAtTarget (player);

                // Move toward player
                /* Vector3 delta =
                    playerTransform.position - this.transform.position;
                delta.Normalize();
                this.transform.position +=
                    delta * distancePerSecond * Time.deltaTime; */
                float step = distancePerSecond * Time.deltaTime;
                Vector3 playerPosition =
                    new Vector3(playerTransform.position.x,
                        0,
                        playerTransform.position.z);
                transform.position =
                    Vector3
                        .MoveTowards(transform.position, playerPosition, step);
            }
        }
    }

    // Stop movement
    private void OnTriggerEnter(Collider collision)
    {
        // Check if player has entered radius
        if (collision.gameObject.CompareTag("Player"))
        {
            // Stop moving toward player
            followPlayer = false;
        }
    }

    // Start movement
    private void OnTriggerExit(Collider collision)
    {
        // Check if player has left radius
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start moving toward player
            followPlayer = true;
        }
    }
}
