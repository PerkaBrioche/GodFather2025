using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("LIST OF SPLINE WOUNDS")]

    public List<SplineData> RightHandData;
    public List<SplineData> LeftHandData;
    public List<SplineData> BodyData;
    
    private SplineData _currentSplineData;
    
    
    [Header("Reference")]
    [SerializeField] private Transform woundsParent;
    [SerializeField] private Transform safeZoneTransform;

    [SerializeField] float timeLimit = 60;
    
    private RaycastDetector _raycastDetector;
    
    
    // PRIVATE VARIABLE
    
    private bool won = false;
    
    private SplineWoundsController _currentSplineWound;

    public static GameManager Instance;
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
        _raycastDetector = FindFirstObjectByType<RaycastDetector>();
        
    }

    private void Start()
    {
        StartGame();
    }
    


    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartGame()
    {
        GetRandomBodyData();
        SetUpBody();
        SpawnWounds();
        Mouse.current.WarpCursorPosition(Camera.main.WorldToScreenPoint(_currentSplineData.mouseSpawner.position));
        TimerManager.Instance.IntializeTimer();
        _raycastDetector.enabled = true;
    }

    public void SetUpBody()
    {
        if (_currentSplineData == null)
        {
            Debug.LogError("CurrentSplineData is null. Cannot set up body.");
            return;
        }
        _currentSplineData.Body.SetActive(true);
        
        
        
    }

    public void SpawnWounds()
    {
        var sp=  Instantiate(_currentSplineData.splineOnBody, _currentSplineData.splineSpawner.position, Quaternion.identity, _currentSplineData.splineSpawner);
        _currentSplineWound = sp.GetComponentInChildren<SplineWoundsController>();
        _currentSplineWound.InitializeSplineWounds();
        if (_currentSplineWound == null)
        {
            throw new NullReferenceException("No SplineWoundsController found on the instantiated spline wound prefab.");
        }
    }

    private void FixedUpdate()
    {
        print(won);
        if (won) return;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (AreAllWoundsHealed())
        {
            Win();
        }
    }

    private void Win()
    {
        won = true;
        TimerManager.Instance.StopTimer();
        timerPlayer.instance.DecreaseTimerDuration();
        _raycastDetector.enabled = false;
        CanvasManager.Instance.ShowVictoryScreen();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    
    public bool AreAllWoundsHealed()
    {
        if (_currentSplineWound == null) return false;
        return _currentSplineWound.AllWoundsHealed();
    }
    
    
    public void GetRandomBodyData()
    {
        int randomBody = Random.Range(0, 3); 
        
        switch (randomBody)
        {
            case 0: // BODY
                _currentSplineData = BodyData[Random.Range(0, BodyData.Count)];
                break;
            case 1: // RIGHT HAND
                _currentSplineData = RightHandData[Random.Range(0, RightHandData.Count)];
                break; 
            case 2: // LEFT HAND
                _currentSplineData = LeftHandData[Random.Range(0, LeftHandData.Count)];
                break;
        }
        
    }
    
    [Serializable]
    public class SplineData
    {
        public GameObject Body;
        public GameObject splineOnBody;
        public Transform splineSpawner;
        public Transform mouseSpawner;
    }
}
