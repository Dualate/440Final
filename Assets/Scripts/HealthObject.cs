using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{

    private void Start()
    {
        Destroy(this.gameObject, 12);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Meteor"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Pickup();
            GameObject.Find("Player").GetComponent<PlayerHealth>().GainHealth();
            Destroy(this.gameObject);
        }
    }
}
