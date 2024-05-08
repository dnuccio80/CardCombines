using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{

    public event EventHandler OnLevelPlaying;

    [SerializeField] private int levelNumber;
    [SerializeField] private float playingTimer;
    [SerializeField] private int coinsEarned; 
    
    private int cardsAmount;
    private CardContainer cardContainer;
    
    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GamaManager_OnGameStateChanged;
        cardContainer = GetComponentInChildren<CardContainer>();
        if (cardContainer != null) cardsAmount = cardContainer.transform.childCount;
        Hide();
    }

    private void GamaManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        (e.gameState != GameManager.GameState.LevelSelection && GameManager.Instance.GetLevelNumber() == levelNumber ? (Action) Show : Hide)();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        OnLevelPlaying?.Invoke(this, EventArgs.Empty);
        GameManager.Instance.SetPlayingConfig(playingTimer, cardsAmount, coinsEarned);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
