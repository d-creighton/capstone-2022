using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //public bool canAttack = false;
    public CompanionAttackState attackChoice;
    public CompanionIdleState giveCommand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackChoice(int choice)
    {
        attackChoice.attackStrength = choice;
        giveCommand.commandReceived = true;
    }

    public void WeakAttack()
    {

    }

    public void StrongAttack()
    {

    }
}
