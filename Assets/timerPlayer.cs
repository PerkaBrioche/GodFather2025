using System;
using UnityEngine;

public class timerPlayer : MonoBehaviour
{
    public static timerPlayer instance; 
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        if(PlayerPrefs.GetInt("newGame") == 1)
        {
            PlayerPrefs.SetFloat("timer", 60f);
            PlayerPrefs.SetInt("newGame", 0);
        }
    }

    public void DecreaseTimerDuration()
    {
        PlayerPrefs.SetFloat("timer", PlayerPrefs.GetFloat("timer")  -5f);
    }

    public void ResetTimer()
    {
        PlayerPrefs.SetFloat("timer", 60);
        PlayerPrefs.SetInt("newGame", 1);
    }

    public float GetTimer()
    {
        return PlayerPrefs.GetFloat("timer");
    }
    
    private void OnApplicationQuit()
    {
        ResetTimer();
    }
}

