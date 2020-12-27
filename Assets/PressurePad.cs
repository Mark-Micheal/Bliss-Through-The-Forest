using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    int charCount = 0;
    public GameObject gate1;
    public GameObject gate2;
    public GameObject Gate;
    public GameObject treeBlock;
    public GameObject fightingInteraction;
    FightingInteraction ft;
    // Start is called before the first frame update
    void Start()
    {
        ft = fightingInteraction.GetComponent<FightingInteraction>();
    }

    // Update is called once per frame
    void Update()
    {

/*        Debug.Log(charCount);
        if(charCount > 2)
        {
            gate1.SetActive(false);
            gate2.SetActive(false);
            Gate.GetComponent<BoxCollider>().enabled = false;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if(other.tag == "Player")
        {
            if (ft.IsFightingComplete())
            {
                gate1.SetActive(false);
                gate2.SetActive(false);
                //Gate.SetActive(false);
                Gate.GetComponent<BoxCollider>().enabled = false;
                treeBlock.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        charCount = 0;
    }


}
