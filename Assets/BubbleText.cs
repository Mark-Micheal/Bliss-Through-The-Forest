using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleText : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        RotateTowards(player);
    }

        public void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}
