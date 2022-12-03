using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject boss;
    //public bool hasTurned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool LookAtTarget()
    {
        //boss = GameObject.FindWithTag("Enemy");
        Transform bossTransform = boss.GetComponent<Transform>();

        Vector3 direction = bossTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        return true;
    }
}
