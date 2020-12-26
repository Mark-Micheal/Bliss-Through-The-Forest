using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Triggered");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collider Player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collider Exited");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Left");
        }
    }
}
