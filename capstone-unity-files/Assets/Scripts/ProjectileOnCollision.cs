using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (
            collision.gameObject.CompareTag("Enemy")
        )
        {
            // Call TakeDamage for target
            Properties targetProp = collision.gameObject.GetComponent<Properties>();
            targetProp.TakeDamage(targetProp.attackChoiceOfAttacker);

            // Destroy projectile
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Friendly"))
        {
            // Call TakeDamage for target
            Properties targetProp = collision.gameObject.GetComponent<Properties>();
            targetProp.TakeDamage(25);

            // Destroy projectile
            Destroy(this.gameObject);
        }
        else
        {
            // Destroy projectile
            Destroy(this.gameObject);
        }
    }
}
