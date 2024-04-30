using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMatchCardsVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionAmountText;

    private void Start()
    {
        PlayerStats.OnShowCardMatchAmountChange += PlayerStats_OnShowCardMatchAmountChange;
        UpdateVisual();
    }

    private void PlayerStats_OnShowCardMatchAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        potionAmountText.text = "x" + PlayerStats.GetShowMatchCardPotionAmount();
    }
}
