using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightingInteraction : MonoBehaviour
{
    bool playerInZone;
    public GameObject kidA;
    AnimationController animControllerA;
    public GameObject kidB;
    AnimationController animControllerB;

    public GameObject Player;
    public bool FollowPlayer;
    Quaternion playerRot;

    public bool FightingChallengeCompleted;
    // Start is called before the first frame update
    void Start()
    {
        animControllerA = kidA.GetComponent<AnimationController>();
        animControllerB = kidB.GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FightingChallengeCompleted)
        {
            // follow player
            animControllerA.StopFighting();
            animControllerB.StopFighting();
            animControllerA.player = Player.transform;
            animControllerA.follow = true;
            animControllerB.player = Player.transform;
            animControllerB.follow = true;
        }
        else
        {

            if (playerInZone)
            {
                // pause fighting and look at player

                animControllerA.StopFighting();
                animControllerA.RotateTowards(Player.transform);

                animControllerB.StopFighting();
                animControllerB.RotateTowards(Player.transform);

                //kidA.transform.rotation = Quaternion.Slerp(kidA.transform.rotation, Quaternion.LookRotation(lookAtTarget), 5 * Time.deltaTime);
                //LookAt();
                //kidA.transform.rotation = Quaternion.Slerp(kidA.transform.rotation, Quaternion.LookRotation(lookAtTarget), 5 * Time.deltaTime);

            }
            else
            {
                // keep fighting
                animControllerA.Fighting();
                animControllerA.RotateTowards(kidB.transform);

                animControllerB.Fighting();
                animControllerB.RotateTowards(kidA.transform);
                //Debug.Log(transform.parent)
                //Vector3 lookAtTarget = kidB.transform.position;
                //Quaternion playerRot = Quaternion.LookRotation(lookAtTarget);
                //Debug.Log(lookAtTarget);
                //kidA.transform.rotation = Quaternion.Slerp(kidA.transform.rotation, Quaternion.LookRotation(lookAtTarget), 5 * Time.deltaTime);
                //kidA.transform.LookAt(lookAtTarget);
            }

        }


    }

    private void LookAt()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Triggered");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collider Player");
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collider Exited");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Left");
            playerInZone = false;
        }
    }
}
