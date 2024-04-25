using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform[] positions;
    NavMeshAgent agent;
    int positionIndex = 0;

    public int max_hp = 3;
    int current_hp;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        current_hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp < 1)
        {
            Destroy(this.gameObject);
        }
       /** agent.destination = positions[positionIndex].position;
        if (Vector3.Distance(transform.position, agent.destination) < 3f)
         {
             if (positionIndex == positions.Length - 1)
             {
                 positionIndex = 0;
             }
             else
             {
                 positionIndex += 1;
             }

         }
       */
    }

    
    public void TakeDamage()
    {
        current_hp -= 1;
    }
}
