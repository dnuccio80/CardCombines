using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmountText;

    private void Start()
    {
        PlayerStats.OnCoinsAmountChange += PlayerStats_OnCoinsAmountChange;
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        UpdateVisual();
        //Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        //(e.gameState != GameManager.GameState.LevelSelection ? (Action)Show : Hide)();
    }

    private void PlayerStats_OnCoinsAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        coinAmountText.text = "x" + PlayerStats.GetCoinsAmount();
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
