using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public bool gameOver = false;
    public int Coins = 0;
    float score = 0;
    public Text txt;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
            score = (int) Time.realtimeSinceStartup * 3 + 12;
            txt.text = score.ToString();
        }
        else
            score = 0;
    }
    void FixedUpdate()
    {
        if (gameOver)
        {
            
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
            Coins++;
            Debug.Log(Coins);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            gameOver = true;
            
            body.isKinematic = true;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log((int)score);
        }

    }

}
