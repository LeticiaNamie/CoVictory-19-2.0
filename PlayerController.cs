using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource scoreAS, hitAS, vaccineAS, jumpAS, xpAS, gameOverAS, winAS;
	Rigidbody2D playerRigidbody;
	bool clicked, win = false, lose = false;
	float position;
    
    public int xp, gameLevel;

	public GameObject Player, BackgroundSound;

    public AudioClip scoreSound, hitSound, vaccineSound, jumpSound, xpSound, gameOverSound, winSound;

    public Text gameOverText;
    public Text youWinText;
    public Text instructionsText;
    public Text xpText;
    public Text winInstructions;

    void Start()
    {
    	Time.timeScale = 1;
        playerRigidbody = GetComponent<Rigidbody2D>();
        GameManager.Instance.GameStarted = false;
        GameManager.Instance.GameOver = false;

        scoreAS = gameObject.AddComponent<AudioSource>();
        hitAS = gameObject.AddComponent<AudioSource>();
        vaccineAS = gameObject.AddComponent<AudioSource>();
        jumpAS = gameObject.AddComponent<AudioSource>();
        xpAS = gameObject.AddComponent<AudioSource>();
        gameOverAS = gameObject.AddComponent<AudioSource>();
        winAS = gameObject.AddComponent<AudioSource>();
        
        hitAS.clip = hitSound;
        scoreAS.clip = scoreSound;
        vaccineAS.clip = vaccineSound;
        jumpAS.clip = jumpSound;
        xpAS.clip = xpSound;
        gameOverAS.clip = gameOverSound;
        winAS.clip = winSound;
    }

    // Update is called once per frame
    void Update()
    { 
    	position = Player.transform.position.y;

        if (Input.GetButtonDown("Jump"))
        {
            if (!GameManager.Instance.GameStarted)
            {
                GameManager.Instance.GameStarted = true;
            }

            if (!GameManager.Instance.GameOver && position <= -245)
            {
                clicked = true;
            }

        }

        if(!GameManager.Instance.GameOver && win)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Level 1");
                
                win = false;
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Level 2");

                win = false;
            }
            else if(gameLevel != 1 && Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadScene("Level 3");

                win = false;
            }
            else if(Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("Menu");

                win = false;
            }

        }
        else if(!GameManager.Instance.GameOver && lose)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Level 1");
                
                lose = false;
            }
            else if(gameLevel != 1 && Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Level 2");

                lose = false;
            }
            else if(gameLevel == 3 && Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadScene("Level 3");

                lose = false;
            }
            else if(Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("Menu");

                lose = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (clicked)
        {
            playerRigidbody.velocity = Vector2.up * GameManager.Instance.ClickForce;
            clicked = false;

            jumpAS.Play();
        }

    }

    public void ChangeXp(int points, int i)
    {
        if(i == 1)
        {
            vaccineAS.Play();
        }
        else if(i == 2)
        {
            xpAS.Play();
        }
        else
        {
            scoreAS.Play();
        }

        xp += points;

        xpText.text = "xp: " + xp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.GameOver)
            return;

        else
        {
            if(collision.CompareTag("Score"))
            {
                ChangeXp(10, 0);

                Vector3 curPos = collision.gameObject.transform.position;

                curPos.x = 620;

                collision.gameObject.transform.position = new Vector3(curPos.x, curPos.y, curPos.z);

                collision.gameObject.SetActive(false);
            }
            else if(collision.CompareTag("Vaccine"))
            {
                ChangeXp(30, 1);

                BackgroundSound.SetActive(false);

                winAS.Play();

                Time.timeScale = 0;
                youWinText.gameObject.SetActive(true);
                instructionsText.gameObject.SetActive(true);

                if(gameLevel != 3)
                {
                    winInstructions.gameObject.SetActive(true);
                }

                win = true;
            }
            else
            {
                hitAS.Play();

                BackgroundSound.SetActive(false);

                gameOverAS.Play();

                Time.timeScale = 0;
                gameOverText.gameObject.SetActive(true);
                instructionsText.gameObject.SetActive(true);

                lose = true;
            }
        }

    }

}
