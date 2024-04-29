using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinMenu : MonoBehaviour
{

    private const string SHOW_ANIMATION = "Show";
    private const string HIDE_ANIMATION = "Hide";


    [SerializeField] private GameWinUI gameWinUI;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button goShopButton;
    [SerializeField] private Button mainMenuButton;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        nextLevelButton.onClick.AddListener(() =>
        {

        });

        goShopButton.onClick.AddListener(() =>
        {

        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

    }

    private void Start()
    {
        gameWinUI.OnGameWinShow += GameWinUI_OnGameWinShow;
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
