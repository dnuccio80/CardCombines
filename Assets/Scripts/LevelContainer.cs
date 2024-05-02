using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{

    [SerializeField] private int levelNumber;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GamaManager_OnGameStateChanged;
        Hide();
    }

    private void GamaManager_OnGameStateChanged(object sender, GameManager.OnGameStateChangedEventArgs e)
    {
        if(e.gameState == GameManager.GameState.CountDownNew && GameManager.Instance.GetLevelNumber() == levelNumber)
        {
            Show();
        } else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
