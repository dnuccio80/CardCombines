using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    [SerializeField] private Button extraTimeButton;
    [SerializeField] private Button showMatchCardsButton;
    [SerializeField] private Button showAllCardsButton;

    private void Awake()
    {
        extraTimeButton.onClick.AddListener(() =>
        {
            PlayerStats.TryIncrementExtraTimePotion(this, extraTimeButton.GetComponent<PotionButton>().GetPotionCost());
        });

        showMatchCardsButton.onClick.AddListener(() =>
        {
            PlayerStats.TryIncrementShowMatchCardPotion(this, showMatchCardsButton.GetComponent<PotionButton>().GetPotionCost());
        });

        showAllCardsButton.onClick.AddListener(() =>
        {
            PlayerStats.TryIncrementShowAllCardsPotion(this, showAllCardsButton.GetComponent<PotionButton>().GetPotionCost());
        });


    }




}
