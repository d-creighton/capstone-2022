using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionIdleState : State
{
    public SeekingState seekingState;

    public bool commandReceived = false;

    //public bool isIdle = true;
    //public GameObject thisUnit;
    //public AudioSource cry;
    public override State RunCurrentState()
    {
        // Await commands from player
        // Wander slightly
        // Cry semi-randomly
        // enumerate seconds
        // random number of seconds
        // if just cried
        // wait at least x number of seconds
        // repeat
        //take weighted number to determine cry
        //pokemonCry = GetComponent<AudioSource>();
        //pokemonCry.Play();
        //cry = GetComponent<AudioSource>();
        //cry.Play();
        //StartCoroutine(CryRepeater());
        // Dodge boss attacks
        // Execute small auto-attacks
        //Debug.Log("Torterra is awaiting commands.");
        if (commandReceived)
        {
            commandReceived = false;
            return seekingState;
        }
        else
        {
            return this;
        }
    }
    /*
    private IEnumerator CryRepeater()
    {
        while(isIdle)
        {
            yield return new WaitForSeconds(5f);
            cry.Play();
        }
    }
*/
}
