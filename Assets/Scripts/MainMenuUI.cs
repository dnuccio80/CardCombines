using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button howToPlayButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        playGameButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        howToPlayButton.onClick.AddListener(() =>
        {

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
