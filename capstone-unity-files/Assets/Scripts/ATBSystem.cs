using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATBSystem : MonoBehaviour
{
    public Slider ATBbar;
    public Text ATBtext;

    public int maxATB = 100;
    public int currentATB;
    public bool isGenerating;
    
    // ATB regen rate
    public WaitForSeconds regenTick = new WaitForSeconds(.1f);

    // Start is called before the first frame update
    void Start()
    {
        currentATB = 0;
        ATBbar.maxValue = maxATB;
        ATBbar.value = currentATB;
        ATBtext.text = "MP " + currentATB + "/" + maxATB;

        // begin to generate ATB when the game starts
        StartCoroutine(GenerateATB());
    }

    // use resources built up during the battle
    public void UseATB(int amount)
    {
        if(currentATB - amount >= 0)
        {
            currentATB -= amount;
            ATBbar.value = currentATB;
            ATBtext.text = "MP " + currentATB + "/" + maxATB;

            if(currentATB < maxATB && !isGenerating)
            {
                StartCoroutine(GenerateATB());
            }
        }
        else
        {
            Debug.Log("Not enough ATB");
        }
    }

    private IEnumerator GenerateATB()
    {
        yield return new WaitForSeconds(1f);

        while(currentATB < maxATB)
        {
            isGenerating = true;
            currentATB += maxATB / 100;
            ATBbar.value = currentATB;
            yield return regenTick;
            ATBtext.text = "MP " + currentATB + "/" + maxATB;
        }
        if(currentATB == maxATB)
        {
            isGenerating = false;
            
        }
    }
}
