using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeInSeconds = 0;
    public TextMeshProUGUI text;
    public bool timerStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeInSeconds < 0)
        {
            timeInSeconds = 0;
        }
        if (timerStarted == true)
        {
            timeInSeconds += Time.fixedDeltaTime;
        }
        

        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100); // Calculate milliseconds

        //string negativeSign = (timeInSeconds < 0) ? "-" : "";

        // Update the text to show minutes, seconds, and milliseconds
        text.text = minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("00");
        //time += Time.fixedDeltaTime;
        //text.text = "Time:\n" + time.ToString("0.0");

        
    }
    public void SubtractSeconds(float secondsToSubtract)
    {
        timeInSeconds -= secondsToSubtract;
    }
}
