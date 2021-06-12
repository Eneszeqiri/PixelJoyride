using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public GameObject Background1;
    public GameObject Background2;
    public GameObject Background3;
    StoreScript st = new StoreScript();


    void Start()
    {
        if (PlayerPrefs.HasKey("ChosenScene"))
        {
            if (PlayerPrefs.GetInt("ChosenScene") == 1)
            {
                Background2.GetComponent<SpriteRenderer>().enabled = true;
                Background1.GetComponent<SpriteRenderer>().enabled = false;
                Background3.GetComponent<SpriteRenderer>().enabled = false;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 20);
            }
            else {
                Background2.GetComponent<SpriteRenderer>().enabled = false;
                Background1.GetComponent<SpriteRenderer>().enabled = false;
                Background3.GetComponent<SpriteRenderer>().enabled = true;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 20);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            transform.position += new Vector3(10f * Time.deltaTime, 0,0);
        }

    }
}
