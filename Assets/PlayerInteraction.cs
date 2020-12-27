using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteraction : MonoBehaviour
{
    float timer = 0.0f;
    public TextMeshProUGUI timerText;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int) timer;
        timerText.text = "Timer: " + seconds.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "EndZone")
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
