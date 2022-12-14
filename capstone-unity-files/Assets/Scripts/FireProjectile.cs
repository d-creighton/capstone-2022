using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject projectile; // Projectile to be fired

    public float force = 10f; // Force of firing

    public float offset = 2f; // Instantiation offset

    private Object[] prefabs;

    private string[] pfRoots;

    void Start()
    {
        prefabs = Resources.LoadAll("Prefabs");
        pfRoots = new string[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            // Find projectile prefab
            //Debug.Log(pfRoots[i]);
            if (prefabs[i].ToString() == "Projectile (UnityEngine.GameObject)")
            {
                projectile = prefabs[i] as GameObject;
                Debug.Log (projectile);
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet =
            Instantiate(projectile,
            transform.position + transform.forward * offset,
            transform.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        // Force forwards along local z axis
        bulletRB.AddRelativeForce(new Vector3(0, 0, force), ForceMode.Impulse);
    }
}
