using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Buyfirst;
    public GameObject BuySecond;
    public int flag = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Buy1() {
        PlayerPrefs.SetInt("ChosenScene",1);
    }

    public void Buy2()
    {
        PlayerPrefs.SetInt("ChosenScene", 2);
        
    }
    void Update()
    {
        
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
