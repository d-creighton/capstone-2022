using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public CompanionAttackState attackChoice;

    public CompanionIdleState giveCommand;

    public GameObject targetRef;

    public Properties targetRefProp;

    public GameObject rootObject;

    public Transform rootTransform;

    public Button button1;

    public Button button2;

    public FireProjectile fireProjectile;

    void Start()
    {
        rootTransform = this.transform.root;
        rootObject = rootTransform.gameObject;

        fireProjectile = gameObject.GetComponent<FireProjectile>();

        // companion will always attack boss
        if (rootObject.CompareTag("Friendly"))
        {
            targetRef = GameObject.FindWithTag("Enemy");
            targetRefProp = targetRef.GetComponent<Properties>();

            attackChoice =
                GameObject
                    .FindWithTag("AI Attack State")
                    .GetComponent<CompanionAttackState>();
            giveCommand =
                GameObject
                    .FindWithTag("AI Idle State")
                    .GetComponent<CompanionIdleState>();

            // reassign listeners to attack buttons when companion is revived
            Button[] activeAndInactive =
                GameObject.FindObjectsOfType<Button>(true);
            for (int i = 0; i < activeAndInactive.Length; i++)
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
        targetRefProp = targetRef.GetComponent<Properties>();
        if (choice == 1)
        {
            targetRefProp.attackChoiceOfAttacker = 25;
        }
        else
        {
            targetRefProp.attackChoiceOfAttacker = 50;
        }

        attackChoice.attackStrength = choice;
        giveCommand.commandReceived = true;
    }

    public void WeakAttack()
    {
        //subtract 25  health from target
        targetRefProp = targetRef.GetComponent<Properties>();

        // spawn fireProjectile in direction of target
        fireProjectile.Shoot();
    }

    public void StrongAttack()
    {
        //subtract 50 health from target
        targetRefProp = targetRef.GetComponent<Properties>();

        //spawn fireProjectile in direction of target
        fireProjectile.Shoot();
    }
}
