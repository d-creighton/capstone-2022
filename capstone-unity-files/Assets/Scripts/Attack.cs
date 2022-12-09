using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    //public bool canAttack = false;
    public CompanionAttackState attackChoice;
    public CompanionIdleState giveCommand;
    public GameObject targetRef;
    public Properties targetRefProp;

    public GameObject rootObject;
    public Transform rootTransform;

    public Button button1;
    public Button button2;

    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;

        if (rootObject.CompareTag("Friendly"))
        {
            targetRef = GameObject.FindWithTag("Enemy");
            targetRefProp = targetRef.GetComponent<Properties>();

            attackChoice = GameObject.FindWithTag("AI Attack State").GetComponent<CompanionAttackState>();
            giveCommand = GameObject.FindWithTag("AI Idle State").GetComponent<CompanionIdleState>();

            Button[] activeAndInactive = GameObject.FindObjectsOfType<Button>(true);
            for (int i=0; i<activeAndInactive.Length; i++)
            {
                if (activeAndInactive[i].CompareTag("Button1"))
                {
                    button1 = activeAndInactive[i];
                    button1.onClick.AddListener(() => AttackChoice(1));
                }
                else if (activeAndInactive[i].CompareTag("Button2"))
                {
                    button2 = activeAndInactive[i];
                    button2.onClick.AddListener(() => AttackChoice(2));
                }
            }
        }
    }

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
