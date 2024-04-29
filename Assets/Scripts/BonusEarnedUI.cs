using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusEarnedUI : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() =>
        {

        });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        continueButton.Select();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
