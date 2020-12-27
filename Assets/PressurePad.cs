using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered Pad");
        Debug.Log(collision.gameObject);

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited Pad");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("ControllerCollidertest");
    }


}
