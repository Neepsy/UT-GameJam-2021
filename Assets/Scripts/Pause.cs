using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private bool paused = false;

    public AccessPauseMenu actionMap;

    private void Awake()
    {
        actionMap = new AccessPauseMenu();
    }

    void Start()
    {
        actionMap.Game.Menu.performed += _ => TogglePauseScreen();
    }

    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
    }

    public void TogglePauseScreen()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (!paused)
        {
            Time.timeScale = 0f;
            paused = true;
        }
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
