using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;

public class SellPotsContainer : MonoBehaviour
{
    [Header("ExtraTime Section")]
    [SerializeField] private Button extraTime_subtractButton;
    [SerializeField] private Button extraTime_additionButton;
    [SerializeField] private TextMeshProUGUI extraTime_amountText;

    [Header("ShowMatchCards Section")]
    [SerializeField] private Button showMatchCards_subtractButton;
    [SerializeField] private Button showMatchCards_additionButton;
    [SerializeField] private TextMeshProUGUI showMatchCards_amountText;


    [Header("ShowAllCards Section")]
    [SerializeField] private Button showAllCards_subtractButton;
    [SerializeField] private Button showAllCards_additionButton;
    [SerializeField] private TextMeshProUGUI showAllCards_amountText;

    [Header("PotionsButton")]
    [SerializeField] private PotionButton extraTimeButton;
    [SerializeField] private PotionButton showMatchCardsButton;
    [SerializeField] private PotionButton showAllCardsButton;

    [Header("Coin Visual")]
    [SerializeField] private TextMeshProUGUI coinsAmountText;

    private ShopUI shopUI;
    
    private int extraTimeValue;
    private int showMatchCardsValue;
    private int showAllCardsValue;
    private float valueSellPercent = .6f;




    private void Awake()
    {

        shopUI = GetComponentInParent<ShopUI>();


        extraTime_subtractButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(extraTime_amountText.text);

            if (amount > 0)
            {
                amount--;
                extraTime_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();
            } 
        });

        extraTime_additionButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(extraTime_amountText.text);
            
            if(amount < PlayerStats.GetExtraTimePotionAmount()) 
            {
                amount++;
                extraTime_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();
            }
        });

        showMatchCards_subtractButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(showMatchCards_amountText.text);

            if (amount > 0)
            {
                amount--;
                showMatchCards_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();

            }
        });

        showMatchCards_additionButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(showMatchCards_amountText.text);

            if (amount < PlayerStats.GetShowMatchCardPotionAmount())
            {
                amount++;
                showMatchCards_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();

            }
        });

        showAllCards_subtractButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(showAllCards_amountText.text);

            if (amount > 0)
            {
                amount--;
                showAllCards_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();

            }
        });

        showAllCards_additionButton.onClick.AddListener(() =>
        {
            int amount = int.Parse(showAllCards_amountText.text);

            if (amount < PlayerStats.GetShowAllCardsPotionAmount())
            {
                amount++;
                showAllCards_amountText.text = amount.ToString();
                UpdateCoinsVisual();
                PlayWooshSound();

            } 
        });

    }

    private void Start()
    {
        extraTimeValue = Mathf.CeilToInt(extraTimeButton.GetPotionCost() * valueSellPercent);
        showMatchCardsValue = Mathf.CeilToInt(showMatchCardsButton.GetPotionCost() * valueSellPercent);
        showAllCardsValue = Mathf.CeilToInt(showAllCardsButton.GetPotionCost() * valueSellPercent);

        shopUI.OnDealButtonPressed += ShopUI_OnDealButtonPressed;
    }

    private void ShopUI_OnDealButtonPressed(object sender, System.EventArgs e)
    {
        SellPotions();
        CleanData();
    }

    private void UpdateCoinsVisual()
    {
        int extraTimeQuantity = int.Parse(extraTime_amountText.text);
        int showMatchCardsQuantity = int.Parse(showMatchCards_amountText.text);
        int showAllCardsQuantity = int.Parse(showAllCards_amountText.text);

        int sellValue = extraTimeValue * extraTimeQuantity + showMatchCardsValue * showMatchCardsQuantity + showAllCardsValue * showAllCardsQuantity;

        coinsAmountText.text = sellValue.ToString();
    }

    private void SellPotions()
    {
        int extraTimePotionsSold = int.Parse(extraTime_amountText.text);
        int showMatchCardsPotionsSold = int.Parse(showMatchCards_amountText.text);
        int showAllCardsPotionsSold = int.Parse (showAllCards_amountText.text);
        int coinsEarned = int.Parse(coinsAmountText.text);

        PlayerStats.SellPotions(extraTimePotionsSold, showMatchCardsPotionsSold, showAllCardsPotionsSold, coinsEarned);
    }

    private void CleanData()
    {
        extraTime_amountText.text = "0";
        showMatchCards_amountText.text = "0";
        showAllCards_amountText.text = "0";



        UpdateCoinsVisual();
    }

    private void PlayWooshSound()
    {
        SoundManager.Instance.EmitWooshSound();
    }

}
