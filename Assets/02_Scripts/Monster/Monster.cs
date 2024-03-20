using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }


}