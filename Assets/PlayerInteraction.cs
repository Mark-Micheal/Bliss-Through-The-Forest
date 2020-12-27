using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{
    float timer = 0.0f;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int) timer;
        timerText.text = "Timer: " + seconds.ToString();


    }
}
