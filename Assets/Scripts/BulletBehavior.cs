using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(transform.forward * 300, ForceMode.Impulse);
        Destroy(this.gameObject, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<EnemyBehavior>().TakeDamage();
        }

        /**if (collision.collider.CompareTag("Health"))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().GainHealth();
            Destroy(collision.collider.gameObject);
        }
        */
    }

}
