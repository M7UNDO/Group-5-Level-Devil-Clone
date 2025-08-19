using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool toggle;
    public Toggle loadToggle;

    [Header("UI Elements")]
    [Space(5)]
    public GameObject controlUIPanel;
    public GameObject[] menuUIElements;
    public GameObject newFirstSelected;
    public GameObject menuFirstSelected;
    public TextMeshProUGUI controlsTxt;
    public HighlightText highlightText;

    [Header("Levels")]
    [Space(5)]

    public int tutorialLevel = 1;
    public int level1 = 2;
    public int level = 1;

    private void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ControlPanel()
    {
        toggle = !toggle;

        if (toggle == false)
        {
            controlUIPanel.SetActive(false);
            controlsTxt.color = highlightText.originalColor;
            foreach (GameObject elem in menuUIElements)
            {
                elem.SetActive(true);

            }


            StartCoroutine(SetFirstSelected(menuFirstSelected));
        }

        if (toggle)
        {
            controlUIPanel.SetActive(true);
            foreach (GameObject elem in menuUIElements)
            {
                elem.SetActive(false);
            }

            // Set first selected in control panel
            StartCoroutine(SetFirstSelected(newFirstSelected));
        }
    }

    private IEnumerator SetFirstSelected(GameObject first)
    {
        yield return null; // Wait one frame to ensure UI is active
        EventSystem.current.SetSelectedGameObject(null); // Clear selection
        EventSystem.current.SetSelectedGameObject(first); // Set new selected
    }

    public void LoadLevelNumber()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void LoadLevelToggle()
    {
        if(loadToggle.isOn)
        {
            level = tutorialLevel;
            print(level);
        }
        else
        {
            level = level1;
            print(level);
        }
    }



}
