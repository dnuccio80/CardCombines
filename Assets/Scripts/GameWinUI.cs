using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
{

    public event EventHandler OnGameWinShow;
    public event EventHandler OnGameWinHide;
    [SerializeField] private Button selectionLevelButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        selectionLevelButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.LevelSelectionShopScene);
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
        SoundManager.Instance.EmitWinGameSound();
        OnGameWinShow?.Invoke(this, EventArgs.Empty);
        selectionLevelButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        OnGameWinHide?.Invoke(this, EventArgs.Empty);
    }

}
