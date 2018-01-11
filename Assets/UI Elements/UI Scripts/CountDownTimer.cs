using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {
    
    public Text countdownText;
    public GameObject GameOverScreen;
    private float timeStamp;
    public bool usingTimer = false;

    private void Start()
    {
        SetTimer(300);
    }

    private void Update()
    {
        if(usingTimer)
        {
            SetUIText();
        }
    }
    public void SetTimer(float time)
    {
        if (usingTimer)
        {
            return;
        }
        timeStamp = Time.time + time;
        usingTimer = true;
    }
    public void SetUIText()
    {
        float timeLeft = timeStamp - Time.time;
        if(timeLeft <=0)
        {
            GameOverScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            TimesUp();
            return;
        }
        float minutes;
        float seconds;
        GetTimeValues(timeLeft, out minutes, out seconds);

        
     
    }
    public void GetTimeValues(float time, out float minutes, out float seconds)
    {
        minutes = (int)(time / 60f);
        seconds = (int)((time - minutes * 60));
        countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void TimesUp()
    {
        Debug.Log("TimesUp!!!");
        countdownText.text = "00:00";
        usingTimer = false;
    }
}
