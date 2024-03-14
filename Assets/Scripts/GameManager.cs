using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject gameSceneObject;
    public GameObject winSceneObject;

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void WinGame()
    {
        PauseGame();
        gameSceneObject.SetActive(false);
        winSceneObject.SetActive(true);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
