using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; } 

    public event EventHandler OnHowToPlayButtonPressed;

    [SerializeField] private Button playGameButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;

        playGameButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        howToPlayButton.onClick.AddListener(() =>
        {
            OnHowToPlayButtonPressed?.Invoke(this, EventArgs.Empty);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        playGameButton.Select();
    }


}
