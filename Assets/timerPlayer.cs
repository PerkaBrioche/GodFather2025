using System;
using UnityEngine;

public class timerPlayer : MonoBehaviour
{
    public static timerPlayer instance;

    public float timerBase = 180f;
    public float actualTimer;
    
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

        actualTimer = timerBase;
    }

    public void DecreaseTimerDuration()
    {
        actualTimer -= 10f;

    }

    public void ResetTimer()
    {
        actualTimer = timerBase;
    }

    public float GetTimer()
    {
        return actualTimer;
    }
    



   
}

