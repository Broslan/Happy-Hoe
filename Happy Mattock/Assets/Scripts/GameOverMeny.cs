using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMeny : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject UiCanvas;

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
        UiCanvas.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        UiCanvas.SetActive(true);
    }
}
