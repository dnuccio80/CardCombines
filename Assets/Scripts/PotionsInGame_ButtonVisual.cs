using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsInGame_ButtonVisual : MonoBehaviour
{

    private PotionsInGameUI potionsInGameUI;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        potionsInGameUI = GetComponentInParent<PotionsInGameUI>();
    }

    private void Update()
    {
        image.fillAmount = potionsInGameUI.GetTimer_Percent();
    }

}
