using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && GameIsPaused == false)
        {
            Debug.Log("Pausing...");
            pauseMenuUI.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }
}
