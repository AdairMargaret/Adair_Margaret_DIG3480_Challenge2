using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    Animator anim;
  
    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    private int score;
    private bool facingRight = true;

    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    public Text scoreText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        score = 0;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        SetLivesText();
        SetScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("Integer", 2);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("Integer", 0);
        }

        if(Input.GetKeyDown (KeyCode.LeftArrow))
        {
            anim.SetInteger("Integer", 2);
        }

        if (Input.GetKeyUp (KeyCode.LeftArrow))
        {
            anim.SetInteger("Integer", 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetInteger("Integer", 1);
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            musicSource.clip = musicClipOne;
            musicSource.Play();

        }


    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
          

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();
            SetScoreText();
        }

    }

    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }

        if (count >= 8)
        {
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }

        if (count == 4)
        {
            transform.position = new Vector3(43.25f, -0.85f, 0f);
            lives = 3;
            SetLivesText();
        }

    }

    void SetLivesText()
    {

        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {

            loseText.text = "You Lose";
            Destroy(this);

        }

    }


    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }




}

