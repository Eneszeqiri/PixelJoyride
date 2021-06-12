using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public Text highscore;
    public Text coins;

    private void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {

            highscore.text = "Best time:\n";
            Debug.Log(PlayerPrefs.GetFloat("highscore"));
            highscore.text += (int)PlayerPrefs.GetFloat("highscore");
        }
        else
            highscore.text = "";
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins.text = "Coins:\n";
            coins.text += PlayerPrefs.GetInt("coins");
        }
    }
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

    
}
