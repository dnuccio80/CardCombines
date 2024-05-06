using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public event EventHandler OnDealButtonPressed;

    [SerializeField] private Button sellPotionsButton;
    [SerializeField] private Button backBuyMenuButton;
    [SerializeField] private Button dealButton;
    [SerializeField] private Button backSellMenuButton;
    [SerializeField] private Transform buyShop;
    [SerializeField] private Transform sellShopUI;

    private void Awake()
    {
        sellPotionsButton.onClick.AddListener(() =>
        {
            buyShop.gameObject.SetActive(false);
            sellShopUI.gameObject.SetActive(true);
            dealButton.Select();
            Debug.Log("Button sell clicked");
        });

        backBuyMenuButton.onClick.AddListener(() =>
        {
            Hide();
            LevelSelectionShopVisual.Instance.SelectButton();
        });

        dealButton.onClick.AddListener(() =>
        {
            OnDealButtonPressed?.Invoke(this, EventArgs.Empty);
        });

        backSellMenuButton.onClick.AddListener(() =>
        {
            buyShop.gameObject.SetActive(true);
            sellShopUI.gameObject.SetActive(false);
            sellPotionsButton.Select();
        });


    }

    private void Start()
    {
        LevelSelectionShopVisual.Instance.OnShopButtonPressed += LevelSelectionShopVisual_OnShopButtonPressed;
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        //sellShop.gameObject.SetActive(false);
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState != GameManager.GameState.LevelSelection) Hide();
    }

    private void LevelSelectionShopVisual_OnShopButtonPressed(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        sellPotionsButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
