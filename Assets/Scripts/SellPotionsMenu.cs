using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellPotionsMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ExtraTimeAmountText;
    [SerializeField] private TextMeshProUGUI ShowMatchCardAmountText;
    [SerializeField] private TextMeshProUGUI ShowAllCardAmountText;


    private void Start()
    {
        UpdateVisual();
        Hide();
    }

    private void OnEnable()
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
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
