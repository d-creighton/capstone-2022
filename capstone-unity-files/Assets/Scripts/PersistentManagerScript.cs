using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript Instance { get; private set; }

    //store data here
    /*rate of time: 1 = normal speed
                    0 = frozen
    */
    //public int rateOfTime = 1;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
