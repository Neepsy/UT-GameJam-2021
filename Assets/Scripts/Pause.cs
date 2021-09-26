using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;
  

    private bool paused = false;

  /*  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseScreen();
        }
    }*/

    public void TogglePauseScreen()
    {
        paused = !paused;
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        
        

        if (!paused)
        {
            Time.timeScale = 0.0f;
            pauseScreen.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseScreen.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
