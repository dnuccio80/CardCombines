using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
{

    public event EventHandler OnGameWinShow;
    public event EventHandler OnGameWinHide;

    [SerializeField] private Button gameMenuButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        gameMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
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
        OnGameWinShow?.Invoke(this, EventArgs.Empty);
        gameMenuButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        OnGameWinHide?.Invoke(this, EventArgs.Empty);
    }

}
