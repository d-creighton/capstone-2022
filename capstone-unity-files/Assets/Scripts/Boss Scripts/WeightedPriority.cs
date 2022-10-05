using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedPriority : MonoBehaviour
{
    public List<WeightedValue> weightedValues;

    void Update() 
    {
        //Get weighted value
        //string randomValue = GetRandomValue(weightedValues);
        //Debug.Log(randomValue ?? "No entries found");
    }

    string GetRandomValue(List<WeightedValue> weightedValueList)
    {
        string output = null;

        //Getting a random weight value
        var totalWeight = 0;
        foreach(var entry in weightedValueList)
        {
            totalWeight += entry.weight;
        }
        var randomWeightValue = Random.Range(1, totalWeight + 1);

        //Checking where random weight value falls
        var processedWeight = 0;
        foreach(var entry in weightedValueList)
        {
            processedWeight += entry.weight;
            if(randomWeightValue <= processedWeight)
            {
                output = entry.value;
                break;
            }
        }

        return output;
    }
}
