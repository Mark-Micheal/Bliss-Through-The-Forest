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

    public GameObject button;
    public GameObject skipButton;
    public GameObject star;
    public bool FightingInteractionCompleted;



    // Start is called before the first frame update
    void Start()
    {

        animControllerA = kidA.GetComponent<AnimationController>();
        animControllerB = kidB.GetComponent<AnimationController>();
        button.SetActive(false);
        skipButton.SetActive(false);
        star.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FightingInteractionCompleted)
        {
            // follow player
            animControllerA.StopFighting();
            animControllerB.StopFighting();
            animControllerA.player = Player.transform;
            animControllerA.follow = true;
            animControllerB.player = Player.transform;
            animControllerB.follow = true;

            star.SetActive(true);


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

                // show button

                button.SetActive(true);
                skipButton.SetActive(true);

            }
            else
            {
                // keep fighting
                animControllerA.Fighting();
                animControllerA.RotateTowards(kidB.transform);

                animControllerB.Fighting();
                animControllerB.RotateTowards(kidA.transform);

                // hide button
                button.SetActive(false);
                skipButton.SetActive(false);
            }

        }


    }

    public bool IsFightingComplete()
    {
        if (FightingInteractionCompleted)
        {
            return true;
        }
        else
        {
            return false;
        }
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

    public void FightingInteractionButtonPressed()
    {
        button.SetActive(false);
        skipButton.SetActive(false);
        FightingInteractionCompleted = true;
    }

    public void FightingInteractionSkipButtonPressed()
    {
        playerInZone = false;

    }
}
