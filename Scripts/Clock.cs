using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{

    public float maxTime;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 3600f;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Timer.time += Time.deltaTime;
        float now = maxTime - Timer.time;
        int minutes = ((int)now) / 60;
        int seconds = ((int)now) % 60;
        string display = String.Format("{0,2:00}:{1,2:00}", minutes, seconds);
        text.text = display;
        
    }
}
