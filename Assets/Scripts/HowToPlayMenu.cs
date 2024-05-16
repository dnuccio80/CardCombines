using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{ 

    [SerializeField] private Transform[] demoTransformArray;

    [Header("Next Buttons")]
    [SerializeField] private Button demo1_NextButton;
    [SerializeField] private Button demo2_NextButton;
    [SerializeField] private Button demo3_NextButton;
    [SerializeField] private Button demo4_NextButton;
    [SerializeField] private Button demo5_NextButton;
    [SerializeField] private Button demo6_NextButton;
    [SerializeField] private Button demo7_NextButton;
    [SerializeField] private Button demo8_NextButton;

    [Header("Back Buttons")]
    [SerializeField] private Button demo1_BackButton;
    [SerializeField] private Button demo2_BackButton;
    [SerializeField] private Button demo3_BackButton;
    [SerializeField] private Button demo4_BackButton;
    [SerializeField] private Button demo5_BackButton;
    [SerializeField] private Button demo6_BackButton;
    [SerializeField] private Button demo7_BackButton;
    [SerializeField] private Button demo8_BackButton;



    private void Awake()
    {
        InitButtons();

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

    private void InitButtons()
    {
        // Next Buttons
        demo1_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[0].gameObject.SetActive(false);
            demoTransformArray[1].gameObject.SetActive(true);
            demo2_NextButton.Select();
        });

        demo2_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[1].gameObject.SetActive(false);
            demoTransformArray[2].gameObject.SetActive(true);
            demo3_NextButton.Select();
        });

        demo3_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[2].gameObject.SetActive(false);
            demoTransformArray[3].gameObject.SetActive(true);
            demo4_NextButton.Select();
        });

        demo4_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[3].gameObject.SetActive(false);
            demoTransformArray[4].gameObject.SetActive(true);
            demo5_NextButton.Select();
        });

        demo5_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[4].gameObject.SetActive(false);
            demoTransformArray[5].gameObject.SetActive(true);
            demo6_NextButton.Select();
        });


        demo6_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[5].gameObject.SetActive(false);
            demoTransformArray[6].gameObject.SetActive(true);
            demo7_NextButton.Select();
        });

        demo7_NextButton.onClick.AddListener(() =>
        {
            demoTransformArray[6].gameObject.SetActive(false);
            demoTransformArray[7].gameObject.SetActive(true);
            demo8_NextButton.Select();
        });

        demo8_NextButton.onClick.AddListener(() =>
        {
            Hide();
        });


        //Back Buttons
        demo1_BackButton.onClick.AddListener(() =>
        {
            Hide();
        });

        demo2_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[0].gameObject.SetActive(true);
            demoTransformArray[1].gameObject.SetActive(false);
            demo1_NextButton.Select();
        });

        demo3_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[1].gameObject.SetActive(true);
            demoTransformArray[2].gameObject.SetActive(false);
            demo2_NextButton.Select();
        });

        demo4_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[2].gameObject.SetActive(true);
            demoTransformArray[3].gameObject.SetActive(false);
            demo3_NextButton.Select();
        });

        demo5_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[3].gameObject.SetActive(true);
            demoTransformArray[4].gameObject.SetActive(false);
            demo4_NextButton.Select();
        });

        demo6_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[4].gameObject.SetActive(true);
            demoTransformArray[5].gameObject.SetActive(false);
            demo5_NextButton.Select();
        });

        demo7_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[5].gameObject.SetActive(true);
            demoTransformArray[6].gameObject.SetActive(false);
            demo6_NextButton.Select();
        });

        demo8_BackButton.onClick.AddListener(() =>
        {
            demoTransformArray[6].gameObject.SetActive(true);
            demoTransformArray[7].gameObject.SetActive(false);
            demo7_NextButton.Select();
        });
    }

    private void Show()
    {
        gameObject.SetActive(true);

        for (int i = 0; i < demoTransformArray.Length; i++)
        {
            if (i == 0) demoTransformArray[i].gameObject.SetActive(true);
            else demoTransformArray[i].gameObject.SetActive(false);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
