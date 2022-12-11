using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call TakeDamage for target
            Properties targetProp =
                collision.gameObject.GetComponent<Properties>();
            bool isDead =
                targetProp.TakeDamage(targetProp.attackChoiceOfAttacker);

            if (isDead)
            {
                // Win game
            }

            // Destroy projectile
            Destroy(this.gameObject);
        }
        else if (
            collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Friendly")
        )
        {
            // Call TakeDamage for target
            Properties targetProp =
                collision.gameObject.GetComponent<Properties>();
            bool isDead = targetProp.TakeDamage(25);

            if (isDead)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    // Game over
                }
                else
                {
                    Destroy(collision.transform.root.gameObject);
                }
            }

            // Destroy projectile
            Destroy(this.gameObject);
        } //if (!collision.gameObject.CompareTag("Projectile"))
        else
        {
            // Destroy projectile
            Destroy(this.gameObject);
        }
    }
}
