using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() =>
        {

        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        backButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
