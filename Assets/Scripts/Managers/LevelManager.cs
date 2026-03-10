using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public GameObject pauseMenuUI;
    //public bool isPaused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape)){
           if (isPaused){
                  ResumeGame();
           } else{
                  isPaused = true;
                  pauseMenuUI.SetActive(true);
                  Cursor.lockState = CursorLockMode.None;
                  Time.timeScale = 0f;
           }
        }*/
    }
    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Over()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    /*public void Options()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameOptions);
    }*/

    public void EndLevelScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    /*public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }*/
}
