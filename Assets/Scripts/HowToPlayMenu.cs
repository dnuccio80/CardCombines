using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{

    [SerializeField] private Transform[] demoTransformArray;
    [SerializeField] private Button[] nextButtonArray;
    [SerializeField] private Button[] backButtonArray;

    private void Awake()
    {
        for (int i = 0; i < nextButtonArray.Length; i++)
        {
            //if (i == nextButtonArray.Length -1) continue;

            nextButtonArray[i].onClick.AddListener(() =>
            {
                Debug.Log("Tocando "  + demoTransformArray[i]);
                //demoTransformArray[i].gameObject.SetActive(false);
                //demoTransformArray[i+1].gameObject.SetActive(true);
            });
        }


    }

    private void Start()
    {
        MainMenuUI.Instance.OnHowToPlayButtonPressed += MainMenuUI_OnHowToPlayButtonPressed;
        Hide();
    }

    private void MainMenuUI_OnHowToPlayButtonPressed(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);

        for(int i = 0; i < demoTransformArray.Length; i++)
        {
            if (i == 0) continue;

            demoTransformArray[i].gameObject.SetActive(false);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
