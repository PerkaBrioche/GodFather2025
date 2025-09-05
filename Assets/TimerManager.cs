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

    private bool wasSpeeding;
    
    private float speedTimerDuration;  



    public void IntializeTimer(float timer, float timerSpeed)
    {
        print("INIT");
        maxTimer = timer;
        actualTimeLeft = timer;
        this.timerSpeed = timerSpeed;
        actualTimeLeft = timer;
        timerActive = true;
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
    
    private void Update()
    {
        if(!timerActive) return;
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (speedTimerDuration > 0f)
        {
            speedTimerDuration -= Time.deltaTime;
            wasSpeeding = true;
            timerSpeed = 1.75f;
            timerText.color =Color.red;
        }else if (wasSpeeding)
        {
            wasSpeeding = false;
            timerSpeed = 1f;
            timerText.color = Color.white;
        }
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

    void UpdateTextAnimation()
    {
        float wavesize = Mathf.Lerp(0, 0.12f, actualTimeLeft / maxTimer);
        textAnimatorBehavior.baseDelay = wavesize;
    }
    
    public void StopTimer()
    {
        timerActive = false;
    }
    
    public void StartTimerSpeeding()
    {
        speedTimerDuration = 2f;
    }
    
}


