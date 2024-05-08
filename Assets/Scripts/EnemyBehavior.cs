using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public int max_hp;
    int current_hp;

    public Transform player;
    public float attackRange = 10f;
    NavMeshAgent agent;
    Animator animator;
    bool attacking = false;

    [SerializeField] EnemyHealthBar healthBar;

    private void Start()
    {
        current_hp = max_hp;
        //find health bar
        healthBar = GetComponentInChildren<EnemyHealthBar>(); 
        //update health
        healthBar.updateHealthBar(current_hp, max_hp);

        player = GameObject.Find("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp < 1)
        {
            Destroy(this.gameObject);
        }

        //if the player isn't in attack range
        if (Vector3.Distance(transform.position, player.position) > attackRange)
        {
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

    public void TakeDamage()
    {
        current_hp -= 1;
        healthBar.updateHealthBar(current_hp, max_hp);
    }
}
