using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        navMeshAgent.destination = FindObjectOfType<PlayerMovimentation>().gameObject.transform.position;
    }
}
