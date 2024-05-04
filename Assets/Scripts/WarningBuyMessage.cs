using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBuyMessage : MonoBehaviour
{

    private const string POPUP_ANIMATION = "PopUpMessage";

    private Animator animator;
    private bool showMessage;

    private float showTimer;
    private float showTimerMax = .8f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerStats.OnWithoutEnoughCoins += PlayerStats_OnWithoutEnoughCoins;
        showTimer = showTimerMax;
        Hide();
    }

    private void PlayerStats_OnWithoutEnoughCoins(object sender, System.EventArgs e)
    {
        showMessage = true;
        Show();
    }


    private void Update()
    {
        if (showMessage)
        {
            showTimer -= Time.deltaTime;

            if(showTimer <= 0)
            {
                showMessage = false;
                showTimer = showTimerMax;
                Hide();
            }
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP_ANIMATION);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
