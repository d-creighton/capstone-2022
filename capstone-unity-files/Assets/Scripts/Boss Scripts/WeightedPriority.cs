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

    public int total;
    public int randomNumber = 0;
    public static int finalValue;

    public void GenerateRandomWeight()
    {


        //tally the total weight
        foreach(var item in table)
        {
            total += item;

            if(total > 100)
            {
                total = 100;
            }
        }
        
        //draw a random number between 0 and the total weight (100)
        randomNumber = Random.Range(0, total);

        foreach(var weight in table)
        {
            //compare random number to current weight
            if(randomNumber <= weight)
            {
                //award this weight
                
                if(weight==80)
                {
                    //Debug.Log("Targetting AI");
                    finalValue = 2;
                    return;
                }
                else
                {
                    //Debug.Log("Targetting player");
                    finalValue = 1;
                    return;
                }
            }
            else
            {
                randomNumber -= weight;
            }
        }
    }
}
