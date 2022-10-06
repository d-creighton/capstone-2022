using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPriority : MonoBehaviour
{
    public int[] table = 
    { 
        80,     // companion weight
        20      // player weight
    };

    public int total = 100;
    public int randomNumber = 0;
    public static int finalValue;
    //public static bool canExecute = false;

    

    public void GenerateRandomWeight()
    {


        //tally the total weight
        /*foreach(var item in table)
        {
            total += item;
        }
        */
        //draw a random number between 0 and the total weight (100)
        randomNumber = Random.Range(0, total);

        foreach(var weight in table)
        {
            //compare random number to current weight
            if(randomNumber <= weight)
            {
                //award this weight
                Debug.Log("Award: " + weight);
                if(weight==80)
                {
                    finalValue = 2;
                    return;
                }
                else
                {
                    finalValue = 1;
                    return;
                }
                //finalValue = weight;
            }
            else
            {
                randomNumber -= weight;
            }
        }
        //canExecute = false;
        //total = 0;

    }
}
