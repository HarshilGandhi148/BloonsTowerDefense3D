using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to be instantiated
    public Transform bulletSpawnPoint; // The point where the bullet will be spawned

    public float bulletSpeed = 30; // The speed of the bullet
    public float lifetime = 3f; // The lifetime of the bullet before it is destroyed

    public PlayerMovement player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player == null)
        {
            player = GetComponentInParent<PlayerMovement>();
        }
        
        if (player != null)
            Debug.Log("Found the player!");
        else
            Debug.LogWarning("No PlayerMovement found in the scene!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Check if the fire button is pressed
        {
            fireBullet(); // Call the method to fire a bullet
        }
    }

    public void fireBullet()
    {
        // Instantiate the bullet at the spawn point with the same rotation as the weapon
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation*Quaternion.Euler(90, 0, 0));

        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(bulletSpawnPoint.forward.normalized * bulletSpeed, ForceMode.Impulse);

        // Destroy the bullet after a certain lifetime
        StartCoroutine(DestroyBulletAfterTime(bullet, lifetime));
        
    }

    public IEnumerator DestroyBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time); // Wait for the specified time
        Destroy(bullet); // Destroy the bullet after the specified lifetime
    }
}
