using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Timer : MonoBehaviour{
    Stopwatch sw =new Stopwatch();
    public static Timer timer;

    private float elapsedLiftedTime;

    // Start is called before the first frame update
    void Start(){
        if(timer && timer != this)
            Destroy(this);
        else
            timer = this;
        
        elapsedLiftedTime = 0;
    }

    public void startTimer(){
        sw.Start();
    }

    public float calDuration(){  //ms
        float res = elapsedLiftedTime;
        elapsedLiftedTime = 0;
        return res;
    }

    public void stopTimer(){
        sw.Stop();
        float time = sw.ElapsedMilliseconds;
        elapsedLiftedTime += time;
        sw.Reset();
    }

    public float getElapsedTime(){
        return sw.ElapsedMilliseconds;
    }

    public string currentTime(){
        string dateAndTimeVar = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        return dateAndTimeVar;
    }

    public string currentTime4Filepath(){
        string dateAndTimeVar = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        return dateAndTimeVar;
    }
}
