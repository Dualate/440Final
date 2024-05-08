using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public bool timerStart = false;
    public float targetTime = 300.0f; //time in seconds

    public TMP_Text timer = null;

    // Start is called before the first frame update
    void Start()
    {
        timerStart = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //prints timer programs, the fixed update is for the display to work
        if(timerStart)
        {
            //convert the time to an int
            int seconds = (int)targetTime;

            displayTimer(targetTime);

            if(seconds <= 0)
            {
                timerStart = false;
            }
        }
    }

    void Update()
    {
        //checks if the timer has started and tracks its progress
        if(timerStart)
        {
            //start countdown
            targetTime -= Time.deltaTime;

            if(targetTime <= 0.0f)
            {
                Debug.Log("Timer has finished.");

                //game over scene
                timerStart = false;
            }
        }
    }


    //to display in the 00:00 format
    void displayTimer(float timeToDisplay)
    {
        timer.enabled = true;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        string debugOut = string.Format("{0:00}:{1:00}", minutes, seconds);
        //Debug.Log("Timer: " + debugOut);
    }
}