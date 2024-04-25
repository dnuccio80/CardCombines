using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinMenu : MonoBehaviour
{

    private const string SHOW_ANIMATION = "Show";
    private const string HIDE_ANIMATION = "Hide";

    [SerializeField] private Button nextLevelButton;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameWinUI.Instance.OnGameWinShow += GameWinUI_OnGameWinShow;
    }

    private void GameWinUI_OnGameWinShow(object sender, System.EventArgs e)
    {
        Invoke("ShowMenuAnimation", 2f);
    }

    private void ShowMenuAnimation()
    {
        animator.SetTrigger(SHOW_ANIMATION);
        nextLevelButton.Select();
    }
}
