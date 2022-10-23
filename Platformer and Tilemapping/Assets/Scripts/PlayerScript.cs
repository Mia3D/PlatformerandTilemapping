using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public float jumpForce;

    public Text score;

    public Text winLoseText;

    public Text livesText;

    private int scoreValue = 0;

    private int livesCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        livesText.text = "Lives: " + livesCount.ToString();
        winLoseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue>=4)
            {
                winLoseText.text = "You win!\nGame Created by Mia Parent";
                winLoseText.gameObject.SetActive(true);
            }
        }
        else if (collision.collider.tag == "Enemy")
        {
            livesCount -= 1;
            livesText.text = "Lives: " + livesCount.ToString();
            Destroy(collision.collider.gameObject);
            if (livesCount<=0)
            {
                winLoseText.text = "You lose!\nGame Created by Mia Parent";
                winLoseText.gameObject.SetActive(true);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                
                rd2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse); 
            }
        }
    }
}