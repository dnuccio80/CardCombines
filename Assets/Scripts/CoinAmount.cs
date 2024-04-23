using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmountText;

    private void UpdateVisual()
    {
        coinAmountText.text = "x0";
    }


}
