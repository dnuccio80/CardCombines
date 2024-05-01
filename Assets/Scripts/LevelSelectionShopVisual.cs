using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionShopVisual : MonoBehaviour
{
    public static LevelSelectionShopVisual Instance { get; private set; }

    public event EventHandler OnSelectLevelButtonPressed;
    public event EventHandler OnShopButtonPressed;
    public event EventHandler OnOptionsButtonPressed;

    [SerializeField] private Button selectLevelButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        Instance = this;

        selectLevelButton.onClick.AddListener(() =>
        {
            OnSelectLevelButtonPressed?.Invoke(this,EventArgs.Empty);
        });

        shopButton.onClick.AddListener(() =>
        {
            OnShopButtonPressed?.Invoke(this, EventArgs.Empty);

        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        SelectButton();
    }

    public void SelectButton()
    {
        selectLevelButton.Select();
    }
}
