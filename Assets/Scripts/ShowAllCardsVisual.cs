using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAllCardsVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionAmountText;

    private void Start()
    {
        PlayerStats.OnShowAllCardsAmontChange += PlayerStats_OnShowAllCardsAmontChange;
        UpdateVisual();
    }

    private void PlayerStats_OnShowAllCardsAmontChange(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        potionAmountText.text = "x" + PlayerStats.GetShowAllCardsPotionAmount();
    }
}
