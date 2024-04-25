using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinUI : MonoBehaviour
{

    public static GameWinUI Instance {  get; private set; }

    public event EventHandler OnGameWinShow;
    public event EventHandler OnGameWinHide;
    public event EventHandler OnLettersAnimationDone;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GameWin) Show();
        else Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        SoundManager.Instance.EmitWinGameSound();
        OnGameWinShow?.Invoke(this, EventArgs.Empty);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        OnGameWinHide?.Invoke(this, EventArgs.Empty);
    }

    public void LettersAnimationDone()
    {
        OnLettersAnimationDone?.Invoke(this,EventArgs.Empty);
    }
}
