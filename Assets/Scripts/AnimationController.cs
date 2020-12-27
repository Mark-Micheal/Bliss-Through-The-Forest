using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator kidanim;
    NavMeshAgent agent;
    public bool follow;
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        kidanim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + " " + follow);
        if (follow)
        {
            //agent.destination = player.position;
            if (Vector3.Distance(transform.position, player.position) <= 2f)
            {
                StopWalking();
            }
            else
            {
                Walking();
            }
        }

    }

    public void Fighting()
    {
        kidanim.SetBool("Idle", false);
        kidanim.SetBool("Fight", true);
    }

    public void StopFighting()
    {
        kidanim.SetBool("Idle", true);
        kidanim.SetBool("Fight", false);
    }

    public void Walking()
    {
        agent.destination = player.position;
        kidanim.SetBool("Walk", true);
    }

    public void StopWalking()
    {
        agent.destination = transform.position;
        kidanim.SetBool("Walk", false);
    }

    public void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }


}
