using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //public bool canAttack = false;
    public CompanionAttackState attackChoice;
    public CompanionIdleState giveCommand;
    public Properties targetRef;

    public void AttackChoice(int choice)
    {
        attackChoice.attackStrength = choice;
        giveCommand.commandReceived = true;
    }

    public void WeakAttack()
    {
        //subtract 25 (1/4) health from target
        targetRef.TakeDamage(25);
        //spawn projectile in direction of target
    }

    public void StrongAttack()
    {
        //subtract 50 (1/2) health from target
        targetRef.TakeDamage(50);
        //spawn projectile in direction of target
    }
}
