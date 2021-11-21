using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] LoadingScreen loadingModule;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        loadingModule.SceneLoader(0);
    }
    
    public void Exit()
    {
        print("QUIT");
        Application.Quit();
    }
}
