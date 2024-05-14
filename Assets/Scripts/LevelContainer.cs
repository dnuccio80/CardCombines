using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{

    public event EventHandler OnLevelStart;

    [SerializeField] private int levelNumber;
    [SerializeField] private float playingTimer;
    [SerializeField] private int coinsEarned;

    private CardContainer cardContainer;
    private int cardsAmount;

    private void Awake()
    {
        cardContainer = GetComponentInChildren<CardContainer>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GamaManager_OnGameStateChanged;
        cardsAmount = cardContainer.transform.childCount;
    }

    private void GamaManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.CountdownToStart && GameManager.Instance.GetLevelNumber() == levelNumber) Show();
        if (e.gameState == GameManager.GameState.CountdownToStart && GameManager.Instance.GetLevelNumber() != levelNumber) Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        GameManager.Instance.SetPlayingConfig(playingTimer, cardsAmount, coinsEarned);
        OnLevelStart?.Invoke(this, EventArgs.Empty);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
