using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellPotionsMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ExtraTimeAmountText;
    [SerializeField] private TextMeshProUGUI ShowMatchCardAmountText;
    [SerializeField] private TextMeshProUGUI ShowAllCardAmountText;

    private ShopUI shopUI;

    private void Awake()
    {
        shopUI = GetComponentInParent<ShopUI>();
    }

    private void Start()
    {
        UpdateVisual();
        shopUI.OnDealButtonPressed += ShopUI_OnDealButtonPressed;
        Hide();
    }

    private void ShopUI_OnDealButtonPressed(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void OnEnable()
    {
        UpdateVisual();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        ExtraTimeAmountText.text = "x" + PlayerStats.GetExtraTimePotionAmount();
        ShowMatchCardAmountText.text = "x" + PlayerStats.GetShowMatchCardPotionAmount();
        ShowAllCardAmountText.text = "x" + PlayerStats.GetShowAllCardsPotionAmount();
    }



}
