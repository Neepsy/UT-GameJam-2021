using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject confirmExit;
    public GameObject PauseScreen;
    /*   private void Update()
       {
           if (Input.GetKeyDown(KeyCode.Escape))
           {
               ToggleExitConfirm();
           }
       }*/
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleExitConfirm()
    {
        confirmExit.SetActive(!confirmExit.activeSelf);
        PauseScreen.SetActive(false);

    }

    public void ExitDenied()
    {
        PauseScreen.SetActive(true);
        confirmExit.SetActive(!confirmExit.activeSelf);

    }
}
