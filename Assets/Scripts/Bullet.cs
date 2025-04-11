using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // print("Hit " + collision.gameObject.name + "!");
            Destroy(gameObject);
        }
    }
    //         // Assuming the enemy has a script with a method to take damage
    //         Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //         if (enemy != null)
    //         {
    //             enemy.TakeDamage(10); // Adjust the damage value as needed
    //         }
    //         Destroy(gameObject); // Destroy the bullet on impact
    //     }
    //     else if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Destroy(gameObject); // Destroy the bullet on wall impact
    //     }
    // }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
