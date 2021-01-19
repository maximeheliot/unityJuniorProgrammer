using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Function that can receive animation events
    // Functions to play fade In/Out animations

    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _fadeOutAnimationClip;
    [SerializeField] private AnimationClip _fadeInAnimationClip;

    private void Start()
    {
        GameManager.instance.onGameStateChanged.AddListener(HandleGameStateChanged);
    }

    public void OnFadeOutComplete()
    {
        Debug.LogWarning("FadeOut Complete");
    }

    public void OnFadeInComplete()
    {
        Debug.LogWarning("FadeIn Complete");
        
        UIManager.instance.SetDummyCameraActive(true);
    }

    public void FadeIn()
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _fadeInAnimationClip;
        _mainMenuAnimation.Play();
    }

    public void FadeOut()
    {
        UIManager.instance.SetDummyCameraActive(false);
        
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = _fadeOutAnimationClip;
        _mainMenuAnimation.Play();
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        }
    }
}
