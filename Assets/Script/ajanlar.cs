using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ajanlar : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform hedef;
    public int hitCountForAgent;
    public float damageCount;
    public GameController myController;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(hedef.position);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            if(hitCountForAgent != 0)
            {
                hitCountForAgent--;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Target"))
        {
            myController.ReduceHealth(damageCount);
            Destroy(gameObject);
        }
    }
}
