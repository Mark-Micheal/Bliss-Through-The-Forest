using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    Animator kidanim;
    NavMeshAgent agent;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        kidanim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position,player.position) <= 2f)
        {
            Debug.Log("Should stop");
            Stop();
        }
        else
        {
            Debug.Log("Should walk");
            Walk();
        }
    }

    private void Walk()
    {
        agent.destination = player.position;
    }

    private void Stop()
    {
        agent.destination = transform.position;
    }
}
