using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class KnightBehavior : MonoBehaviour
{
    public int max_health = 3;
    int current_health;

    public Transform player;
    public float attackRange = 5f;
    NavMeshAgent agent;
    Animator animator;
    bool attacking = false;
    private void Start()
    {
        current_health = max_health;
        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (current_health < 1)
        {
            Destroy(this.gameObject);
        }
        //if the player isn't in attack range
        if (Vector3.Distance(transform.position, player.position) > attackRange) {
            //set player position as destination
            agent.destination = player.position;
            //start walking animation
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
            agent.destination = transform.position;
            if (!attacking)
                InvokeRepeating("Attack", 0, 1f);

        }
    }

    void Attack()
    {
        attacking = true;
        animator.SetTrigger("Trigger");
    }

    public void TakeDamage() {
        current_health -= 1;
    }


}
