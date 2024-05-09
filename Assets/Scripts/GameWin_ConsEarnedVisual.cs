using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWin_ConsEarnedVisual : MonoBehaviour
{

    private float coinsIncrementorVisual;
    private int previousCoinNumber;
    private bool canInteract;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GameWin)
        {
            coinsIncrementorVisual = 0f;
            canInteract = true;
        } else
        {
            canInteract = false;
        }

    }

    private void Update()
    {
        if (canInteract && coinsIncrementorVisual <= GameManager.Instance.GetCoinsEarned())
        {
            float timeMultiplier = 30f;

            coinsIncrementorVisual += Time.deltaTime * timeMultiplier;

            
            int coinsEarned = Mathf.FloorToInt(coinsIncrementorVisual);

            if(previousCoinNumber != coinsEarned)
            {
                previousCoinNumber = coinsEarned;
                SoundManager.Instance.EmitCoinEarnedSound();
            }


            text.text = coinsEarned.ToString();
            
        }
    }
}
