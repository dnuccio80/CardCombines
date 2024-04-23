using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        tryAgainButton.onClick.AddListener(() =>
        {

        });

        mainMenuButton.onClick.AddListener(() =>
        {

        });
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GameOver) Show();
        else Hide();
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        tryAgainButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
