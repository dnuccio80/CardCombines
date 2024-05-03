using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VaultVisual : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinAmountText;
    [SerializeField] private TextMeshProUGUI extraTimeAmountText;
    [SerializeField] private TextMeshProUGUI showMatchCardAmountText;
    [SerializeField] private TextMeshProUGUI showAllCardsAmountTexts;

    private void Start()
    {
        PlayerStats.OnCoinsAmountChange += PlayerStats_OnCoinsAmountChange;
        PlayerStats.OnShowCardMatchAmountChange += PlayerStats_OnShowCardMatchAmountChange;
        PlayerStats.OnExtraTimeAmountChange += PlayerStats_OnExtraTimeAmountChange;
        PlayerStats.OnShowAllCardsAmontChange += PlayerStats_OnShowAllCardsAmontChange;

        UpdateVisual();
    }

    private void PlayerStats_OnShowAllCardsAmontChange(object sender, System.EventArgs e)
    {
        UpdateVisual();

    }

    private void PlayerStats_OnExtraTimeAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();

    }

    private void PlayerStats_OnCoinsAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();

    }

    private void PlayerStats_OnShowCardMatchAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();

    }


    private void UpdateVisual()
    {
        coinAmountText.text = "x" + PlayerStats.GetCoinsAmount();
        extraTimeAmountText.text = "x" + PlayerStats.GetExtraTimePotionAmount();
        showMatchCardAmountText.text = "x" + PlayerStats.GetShowMatchCardPotionAmount();
        showAllCardsAmountTexts.text = "x" + PlayerStats.GetShowAllCardsPotionAmount();
    }

}
