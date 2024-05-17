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
        UpdateVisual();
    }


    private void PlayerStats_OnCoinsAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        coinAmountText.text = PlayerStats.GetCoinsAmount().ToString();
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
