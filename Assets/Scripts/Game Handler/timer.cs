using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    bool timerActive = false;
    public bool timerGoing = false;
    public float timeRemaining;
    public Text currentTimeText;

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    void Start()
    {
        timeRemaining = 90;
        timerActive = true;
        timerGoing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true) 
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerGoing = false;
                FindObjectOfType<GameManager>().gameOver();
            }
        }
 
        //TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        currentTimeText.text = timeRemaining.ToString("F0");
    }
}
