using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSystem : MonoBehaviour
{
    public int attackChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

/*    public void ChooseCommand(int commandID)
    {
        //if 1 or 2, choose attack
        //if 3 or 4, choose heal
        if(commandID == 1 || 2)
        {
            Attack(commandID);
        }
        else
        {
            Heal(commandID);
        }
    }
*/
    public void Attack()
    {
        int attackChoice;
        //if attack 1
        if(attackChoice == 1)
        {
            //do something
        }
        //if attack 2
        else
        {
            //do something
        }
    }

    public void Heal(int itemChoice)
    {
        //if item 1
        //if item 2
    }
}
