using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemmybehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform targetTransform;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(targetTransform.position);
	}
}
