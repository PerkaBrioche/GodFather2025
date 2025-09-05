using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameStateManager : MonoBehaviour
{
    [SerializeField] GameObject _loseScreen;
    [SerializeField] GameObject _winScreen;

    [SerializeField] TimerManager timerManager;

    private void OnEnable()
    {
        timerManager.OnTimerEnd += OpenLoseScreen;
    }

    private void OnDisable()
    {
        timerManager.OnTimerEnd -= OpenLoseScreen;
    }

    enum UiStateEnum
    {
        GAME,
        LOSE_SCREEN,
        WIN_SCREEN
    }

    UiStateEnum currentState = UiStateEnum.GAME;

    private void Start()
    {
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
    }

    [Button("lose")]
    private void OpenLoseScreen() // call by an event
    {
        _loseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        currentState = UiStateEnum.LOSE_SCREEN;
    }
    [Button("win")]
    private void OpenWinScreen() // call by an event
    {
        _winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        currentState = UiStateEnum.LOSE_SCREEN;
    }

    private void Update()
    {
        
        switch (currentState)
        {
            case UiStateEnum.GAME:
                if (Input.GetKeyDown(KeyCode.R)) StartNewGame();

                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case UiStateEnum.LOSE_SCREEN:
                if (Input.anyKey)
                {
                    StartNewGame();
                }
                break;
            case UiStateEnum.WIN_SCREEN:
                if (Input.anyKey)
                {
                    StartNewGame();
                }
                break;
            default:
                break;
        }
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
