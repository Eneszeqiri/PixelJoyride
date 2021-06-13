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


    void Start()
    {
        if (PlayerPrefs.HasKey("ChosenScene"))
        {
            if (PlayerPrefs.GetInt("ChosenScene") == 1)
            {
                
                if (PlayerPrefs.GetInt("coins") > 20)
                {
                    Background2.GetComponent<SpriteRenderer>().enabled = false;
                    Background1.GetComponent<SpriteRenderer>().enabled = true;
                    Background3.GetComponent<SpriteRenderer>().enabled = false;
                    
                }
                else
                {
                    Debug.Log("You dont have enough Coins!! "); 
                }

            }
            else {

                if (PlayerPrefs.GetInt("coins") > 20)
                {
                    Background2.GetComponent<SpriteRenderer>().enabled = false;
                    Background1.GetComponent<SpriteRenderer>().enabled = false;
                    Background3.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    Debug.Log("You dont have enough Coins!! ");
                }
            }
        }
        else
        {
            Background2.GetComponent<SpriteRenderer>().enabled = false;
            Background1.GetComponent<SpriteRenderer>().enabled = false;
            Background3.GetComponent<SpriteRenderer>().enabled = false;
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
