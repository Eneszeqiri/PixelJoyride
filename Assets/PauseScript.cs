using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject score;
    bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                resume();
            } else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        score.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        score.SetActive(true);
    }

    public void loadMenu()
    {

        paused = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        
    }
}
