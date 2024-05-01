using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    [SerializeField] private Button[] levelSelectionButtonArray;
    
    private int levelSelectionIndex;
    private int maxLevelCompleted;

    private void Start()
    {
        UpdateAvailableButtons();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        levelSelectionButtonArray[levelSelectionIndex].Select();

    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateAvailableButtons()
    {
        foreach (Button button in levelSelectionButtonArray)
        {
            button.enabled = false;
        }

        maxLevelCompleted = PlayerStats.GetMaxLevelCompleted();

        

        for(int i = 0; i <= maxLevelCompleted; i++)
        {
            if (i == levelSelectionButtonArray.Length) break;

            levelSelectionButtonArray[i].enabled = true;
            levelSelectionIndex = i;

            if(levelSelectionButtonArray[i].TryGetComponent<SelectionLevelButton>(out SelectionLevelButton selectionLevelButton))
            {
                selectionLevelButton.UpdateVisual();
            }

            
        }

        levelSelectionButtonArray[levelSelectionIndex].Select();

    }
}
