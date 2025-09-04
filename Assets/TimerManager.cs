using System;
using Febucci.UI.Effects;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    
    

    private float timer;
    private float timerSpeed;
    private float actualTimeLeft;
    private float maxTimer;
    
    private bool timerActive;
    
    public event Action OnTimerEnd;
    
    [SerializeField] private ShakeBehavior textAnimatorBehavior; 
    
    [SerializeField] private TextMeshProUGUI timerText;



    public void IntializeTimer(float timer, float timerSpeed)
    {
        print("INIT");
        maxTimer = timer;
        actualTimeLeft = timer;
        this.timerSpeed = timerSpeed;
        actualTimeLeft = timer;
        timerActive = true;
        
        StartTimer();
    }
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void StartTimer()
    {
    }

    private void Update()
    {
        if(!timerActive) return;
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        actualTimeLeft -= Time.deltaTime * timerSpeed;
        timerText.text = actualTimeLeft.ToString("0.0");
        UpdateTextAnimation();
        if (actualTimeLeft <= 0)
        {
            EndTimer();
        }
    }

    public void EndTimer()
    {
        OnTimerEnd?.Invoke();
        timerActive = false;
    }
    
    public void ChangeSpeedTimer(float newSpeed)
    {
        timerSpeed = newSpeed;
    }

    void UpdateTextAnimation()
    {
        float wavesize = Mathf.Lerp(0, 0.12f, actualTimeLeft / maxTimer);
        textAnimatorBehavior.baseDelay = wavesize;
        
    }
}


