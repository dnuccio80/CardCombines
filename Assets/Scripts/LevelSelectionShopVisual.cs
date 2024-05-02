using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionShopVisual : MonoBehaviour
{
    public static LevelSelectionShopVisual Instance { get; private set; }

    public event EventHandler OnSelectLevelButtonPressed;
    public event EventHandler OnShopButtonPressed;

    [SerializeField] private Button selectLevelButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        Instance = this;

        selectLevelButton.onClick.AddListener(() =>
        {
            OnSelectLevelButtonPressed?.Invoke(this,EventArgs.Empty);
        });

        shopButton.onClick.AddListener(() =>
        {
            OnShopButtonPressed?.Invoke(this, EventArgs.Empty);

        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        SelectButton();
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
       if(e.gameState == GameManager.GameState.LevelSelection)
        {
            Show();
        } else
        {
            Hide();
        }
    }

    public void SelectButton()
    {
        selectLevelButton.Select();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
