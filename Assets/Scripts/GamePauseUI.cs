using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button musicVolumeButton;
    [SerializeField] private Button soundVolumeButton;
    [SerializeField] private Button gameMenuButton;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI soundVolumeText;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.ToggleGamePause();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        musicVolumeButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.IncrementMusicVolume();
            UpdateVisual();
        });

        soundVolumeButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.IncrementSoundVolume();
            UpdateVisual();
        });

        gameMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
        Hide();
    }

    private void GameManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if (e.gameState == GameManager.GameState.GamePaused) Show();
        else Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        resumeButton.Select();
        UpdateVisual();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        float soundMultiplier = 10f;
        musicVolumeText.text = "Music Volume: " + Mathf.Round(MusicManager.Instance.GetMusicVolume() * soundMultiplier);
        soundVolumeText.text = "Sound Volume: " + Mathf.Round(SoundManager.Instance.GetSoundVolume() * soundMultiplier);
    }


}
