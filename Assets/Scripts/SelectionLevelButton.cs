using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLevelButton : MonoBehaviour
{
    private const string LOCK_IMAGE = "lockImage";

    [SerializeField] private int levelNumber;

    private Transform lockImage;
    private TextMeshProUGUI levelText;
    

    private void Awake()
    {
        lockImage = transform.Find(LOCK_IMAGE);
        levelText = GetComponentInChildren<TextMeshProUGUI>();

    }

    public void UpdateVisual()
    {
        if(this.enabled)
        {
            levelText.text = levelNumber.ToString();
            lockImage.gameObject.SetActive(false);
        } else
        {
            levelText.text = string.Empty;
            lockImage.gameObject.SetActive(true);
        }
    }



}
