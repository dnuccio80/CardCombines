using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() =>
        {
            Hide();
            LevelSelectionShopVisual.Instance.SelectButton();
        });

    }

    private void Start()
    {
        LevelSelectionShopVisual.Instance.OnShopButtonPressed += LevelSelectionShopVisual_OnShopButtonPressed;
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
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
        backButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
