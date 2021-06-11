using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void openStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
