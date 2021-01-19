using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    
    [SerializeField] private Camera _dummyCamera;

    public Events.EventFadeComplete onMainMenuFadeComplete;
    
    private void Start()
    {
        _mainMenu.onMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        GameManager.instance.onGameStateChanged.AddListener(HandleGameStateChanged);
    }
    
    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        _pauseMenu.gameObject.SetActive(currentState == GameManager.GameState.PAUSED);
    }

    void HandleMainMenuFadeComplete(bool fadeOut)
    {
        onMainMenuFadeComplete.Invoke(fadeOut);
    }
    
    private void Update()
    {
        if (GameManager.instance.currentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.StartGame();
        }
    }

    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }
}
