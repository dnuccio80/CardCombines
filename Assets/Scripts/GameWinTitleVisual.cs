using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinTitleVisual : MonoBehaviour
{

    private const string POP_UP_ANIMATION = "PopUp";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GameWin) animator.SetTrigger(POP_UP_ANIMATION);
    }
}
