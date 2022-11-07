using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostVerification : MonoBehaviour
{
    public bool canInteract;
    public Button button;

    public int price;

    public ATBSystem ATB;
    public KeyCodeToOnClick verify;

    // Start is called before the first frame update
    void Start()
    {
        if(verify.needsVerified)
        {
            canInteract = false;
        }
        else
        {
            canInteract = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check atb amount
        // set button interactable to true if desired amount reached
        if(ATB.currentATB >= price)
        {
            canInteract = true;
            button.interactable = true;
        }
        else
        {
            canInteract = false;
            button.interactable = false;
        }
    }
}
