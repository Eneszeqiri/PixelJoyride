using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject replay;
    Rigidbody2D body;
    public bool gameOver = false;
    float score = 0;
    public Text txt;


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 15);
        }
        gameOver = false;
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(!gameOver)
        {
            score += Time.deltaTime;
            txt.text = "score:" + (int)score;
        }
        else
        {
            txt.text = "score:" + 0;
            score = 0;
        }
        if (body.transform.position.x == -7 && body.transform.position.y == -1)
        {
            score = 0;
        }

    }
    void FixedUpdate()
    {
        if (gameOver)
        {
            replay.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked");
                SceneManager.LoadScene("SampleScene");
                
            }
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, 50));
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity *= 0.25f;

        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(new Vector2(20, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(new Vector2(-20, 0));
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            collision.gameObject.transform.position = new Vector2(100, 100);
            
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+1);
            Debug.Log(PlayerPrefs.GetInt("coins"));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            if (!PlayerPrefs.HasKey("highscore")) {
                PlayerPrefs.SetFloat("highscore", score);
                
            }
            if(PlayerPrefs.GetFloat("highscore") < score)
            {
                PlayerPrefs.SetFloat("highscore", score);
            }
            gameOver = true;
            score = 0;
            body.isKinematic = true;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log((int)score);
        }
    }

}
