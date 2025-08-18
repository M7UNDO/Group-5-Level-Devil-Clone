using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject newFirstSelected;
    private bool toggle;
    private Controls playerInput;
    public TextMeshProUGUI restartTxt;
    public HighlightText highlightText;

    private System.Action<InputAction.CallbackContext> pauseAction;

    [Header("Pause UI Elements")]
    [Space(5)]
    [SerializeField] private GameObject pausePanel;

    private void OnEnable()
    {
        playerInput = new Controls();
        playerInput.Player.Enable();

        pauseAction = ctx => Pause();
        playerInput.Player.Pause.performed += pauseAction;
    }

    private void OnDisable()
    {
        playerInput.Player.Pause.performed -= pauseAction;
        playerInput.Player.Disable();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        toggle = !toggle;

        if (toggle)
        {
            restartTxt.color = highlightText.highlightColor;
            pausePanel.SetActive(true);
            StartCoroutine(SetFirstSelected(newFirstSelected));
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }

        print("Pause toggled: " + toggle);
    }

    private IEnumerator SetFirstSelected(GameObject first)
    {
        yield return null; 
        EventSystem.current.SetSelectedGameObject(first); 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
