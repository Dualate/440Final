using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherBehavior : MonoBehaviour
{
    public int max_health = 1;
    int current_health;

    public Transform player;
    public float attackRange = 3f;
    NavMeshAgent agent;
    Animator animator;
    bool attacking = false;

    [SerializeField] EnemyHealthBar healthBar;

    private void Start()
    {
        current_health = max_health;
        //find health bar
        healthBar = GetComponentInChildren<EnemyHealthBar>(); 
        //update health
        healthBar.updateHealthBar(current_health, max_health);

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
        healthBar.updateHealthBar(current_health, max_health);
    }
}
