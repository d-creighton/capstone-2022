using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Properties : MonoBehaviour
{
    public string unitName;

    public int unitLevel;

    public int maxHP;

    public int currentHP;

    public BarFunctionality healthBar;

    public GameObject CompanionPrefab;

    public BossIdleState bossIdleState;

    public Button button;

    public int attackChoiceOfAttacker;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("Friendly"))
        {
            bossIdleState =
                GameObject
                    .FindWithTag("Boss Idle State")
                    .GetComponent<BossIdleState>();
            healthBar =
                GameObject
                    .FindWithTag("AI Healthbar")
                    .GetComponent<BarFunctionality>();

            // reassign listeners to heal button when companion is revived
            Button[] activeAndInactive =
                GameObject.FindObjectsOfType<Button>(true);
            for (int i = 0; i < activeAndInactive.Length; i++)
            {
                if (activeAndInactive[i].CompareTag("Heal Button"))
                {
                    button = activeAndInactive[i];
                    button.onClick.AddListener(() => Heal(25));
                }
            }
        }

        currentHP = maxHP;
        healthBar.SetMaxSliderValue (maxHP);
        healthBar.SetLabel (currentHP, maxHP, unitName);
    }

    // Call if projectile hits
    public bool TakeDamage(int damageTaken)
    {
        bossIdleState.wasAttacked = true;

        // Take damage
        currentHP -= damageTaken;
        healthBar.SetValue (currentHP);
        healthBar.SetLabel (currentHP, maxHP, unitName);

        // Check if this unit has died
        if (currentHP <= 0)
        {
            currentHP = 0;
            healthBar.SetValue (currentHP);
            healthBar.SetLabel (currentHP, maxHP, unitName);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int potion)
    {
        Debug.Log("Healing: " + gameObject);
        currentHP += potion;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        healthBar.SetValue (currentHP);
        healthBar.SetLabel (currentHP, maxHP, unitName);
    }

    public void Revive()
    {
        // Spawn companion nearby player
        // Find player's current position
        GameObject player = GameObject.FindWithTag("Player");
        Transform playerTransform = player.GetComponent<Transform>();

        // y axis will always be the same
        float playerX = playerTransform.position.x;
        float playerZ = playerTransform.position.z;

        playerX = playerX + -Random.Range(2.0f, 5.0f);
        playerZ = playerZ + -Random.Range(2.0f, 5.0f);

        //Debug.Log (playerX);
        //Debug.Log (playerZ);
        GameObject torterra =
            Instantiate(CompanionPrefab,
            new Vector3(playerX, 0.1f, playerZ),
            Quaternion.identity);
    }
}
