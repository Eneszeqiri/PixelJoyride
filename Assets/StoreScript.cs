using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Buyfirst;
    public GameObject BuySecond;
    public int flagbtn1 = 0;
    public int flagbtn2 = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Buy1() {
        if(PlayerPrefs.GetInt("coins") >= 20)
        {
            PlayerPrefs.SetInt("ChosenScene", 1);
            if(flagbtn1 == 0)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 20);
                flagbtn1 = 1;
            }
            
        } else
        {
            Debug.Log("You dont have enough money");
        }
    }

    public void Buy2()
    {
        if (PlayerPrefs.GetInt("coins") >= 20)
        {
            PlayerPrefs.SetInt("ChosenScene", 2);
            if (flagbtn2 == 0)
            {
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 20);
                flagbtn2 = 1;
            }
        }
        else
        {
            Debug.Log("You dont have enough money");
        }

    }
    void Update()
    {
        
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
