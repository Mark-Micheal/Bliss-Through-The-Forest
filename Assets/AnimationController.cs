using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour
{
    Animator kidanim;
    NavMeshAgent agent;
    public Transform target;
    public bool follow;

    public Transform Target { get => target; set => target = value; }

    // Start is called before the first frame update
    void Start()
    {
        Target = transform;
        kidanim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + " " + follow);
        if (follow)
        {

            agent.destination = Target.position;
            if (agent.remainingDistance < 1f)
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
        agent.destination = Target.position;
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
