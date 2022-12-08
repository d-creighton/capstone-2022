using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //public bool canAttack = false;
    public CompanionAttackState attackChoice;
    public CompanionIdleState giveCommand;
    public GameObject targetRef;
    public Properties targetRefProp;

    public void AttackChoice(int choice)
    {
        attackChoice.attackStrength = choice;
        giveCommand.commandReceived = true;
    }

    public void WeakAttack()
    {
        //subtract 25 (1/4) health from target
        targetRefProp = targetRef.GetComponent<Properties>();
        bool isDead = targetRefProp.TakeDamage(25);
        //spawn projectile in direction of target

        //check if target has died
        if (isDead)
        {
            //if boss died end game
            if (targetRef.CompareTag("Enemy"))
            {
                //win game
            }
            //if player dies end game
            else if (targetRef.CompareTag("Player"))
            {
                //game over
            }
            //if AI dies delete gameobject
            else
            {
                Destroy(targetRef);
            }
        }
        else
        {
            return;
        }
    }

    public void StrongAttack()
    {
        //subtract 50 (1/2) health from target
        targetRefProp = targetRef.GetComponent<Properties>();
        bool isDead = targetRefProp.TakeDamage(50);
        //spawn projectile in direction of target

        //check if target has died
        if (isDead)
        {
            //if boss died end game
        }
        else
        {
            return;
        }
    }
}
