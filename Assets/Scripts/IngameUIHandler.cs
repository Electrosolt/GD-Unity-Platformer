using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;

    [HideInInspector] bool isTimerRunning = false;
    [HideInInspector] float timeElapsed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
            int seconds = (int) timeElapsed;
            int minutes = seconds / 60;
            seconds %= 60;
            string secondsString = seconds.ToString();
            if (seconds < 10)
            {
                secondsString = "0" + secondsString;
            }

            clock.text = minutes + ":" + secondsString;
        }
        
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        timeElapsed = 0;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }
    
    public void PauseTimer()
    {
        isTimerRunning = false;
    }
    
    public void StopTimer()
    {
        isTimerRunning = false;
        timeElapsed = 0;
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
