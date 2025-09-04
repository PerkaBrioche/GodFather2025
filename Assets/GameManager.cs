using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("LIST OF SPLINE WOUNDS")]
    [SerializeField] private GameObject[] splinesWounds;
    
    
    [Header("Reference")]
    [SerializeField] private Transform woundsParent;
    
    // PRIVATE VARIABLE
    
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
    }

    private void Start()
    {
        StartGame();
    }

    public void InitializeSplineWounds()
    {
        splinesWounds = Resources.LoadAll<GameObject>("SplinesWound");
    }
    
    public void StartGame()
    {
        InitializeSplineWounds();
        SpawnWounds();
        TimerManager.Instance.IntializeTimer(10f,1f);
    }

    public void SpawnWounds()
    {
        int randomIndex = Random.Range(0, splinesWounds.Length);
        var sp=  Instantiate(splinesWounds[randomIndex], woundsParent);
        _currentSplineWound = sp.GetComponent<SplineWoundsController>();
        if (_currentSplineWound == null)
        {
            throw new NullReferenceException("No SplineWoundsController found on the instantiated spline wound prefab.");
        }
    }
}
