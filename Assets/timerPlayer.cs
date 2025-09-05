using System;
using UnityEngine;

public class timerPlayer : MonoBehaviour
{
    public static timerPlayer instance;

    public float timer = 60f;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        timer = 120;
    }

    public void DecreaseTimerDuration()
    {
        timer -= 10f;

    }

    public void ResetTimer()
    {
        timer = 60f;
    }

    public float GetTimer()
    {
        return timer;
    }
    



   
}

