using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestParent : MonoBehaviour
{
    [SerializeField] private Button increaseCoinsButton;

    private void Awake()
    {
        increaseCoinsButton.onClick.AddListener(() =>
        {
            PlayerStats.IncrementCoinsAmount(this);
        });
    }
}
