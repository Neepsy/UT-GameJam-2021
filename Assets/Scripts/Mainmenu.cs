using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmExit;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleExitConfirm();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToggleExitConfirm()
    {
        confirmExit.SetActive(!confirmExit.activeSelf);
    }
}
