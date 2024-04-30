using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtraTimePotionVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI potionAmountText;

    private void Start()
    {
        PlayerStats.OnExtraTimeAmountChange += PlayerStats_OnExtraTimeAmountChange;
        UpdateVisual();
    }

    private void PlayerStats_OnExtraTimeAmountChange(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        potionAmountText.text = "x" + PlayerStats.GetExtraTimePotionAmount();
    }
}
