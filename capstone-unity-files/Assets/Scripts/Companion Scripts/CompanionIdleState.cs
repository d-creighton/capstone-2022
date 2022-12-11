using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionIdleState : State
{
    public SeekingState seekingState;

    public bool commandReceived = false;

    public CompanionMovement movement;

    public Transform rootTransform;

    public GameObject rootObject;

    //public bool isIdle = true;
    //public GameObject thisUnit;
    public AudioSource cry;

    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;
        movement = rootObject.GetComponent<CompanionMovement>();
        cry = rootObject.GetComponent<AudioSource>();
    }

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
        int randomNumber = Random.Range(0, 10);
        if (randomNumber % 2 == 0)
        {
            Debug.Log (randomNumber);
            cry.Play();
        }

        //StartCoroutine(CryRepeater());
        // Dodge boss attacks
        // Execute small auto-attacks
        //Debug.Log("Torterra is awaiting commands.");
        movement.canFollow = true;

        if (commandReceived)
        {
            movement.canFollow = false;
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
