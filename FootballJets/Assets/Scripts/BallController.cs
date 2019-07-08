using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2; 
    public int score1;
    public int score2;
    public Text scoreText;
    public AudioSource soundSource;

    public AudioClip wallHitSfx;
    public AudioClip goalScore;

    private Rigidbody2D rb2d;
   
    // Start is called before the first frame update
    public void PlaySound(AudioClip audioC)
    {
        soundSource.clip = audioC;
        soundSource.Play();

    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetScoreText();
        score1 = 0;
        score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftGoal"))
        {

            PlaySound(goalScore);
            score1 += 1;
            SetScoreText();
            SetPlayerPositions();
        }
        if (other.gameObject.CompareTag("RightGoal"))
        {
            PlaySound(goalScore);
            score2 += 1;
            SetScoreText();
            SetPlayerPositions();
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            PlaySound(wallHitSfx);
        }
    }
    void SetScoreText()
    {
        scoreText.text = score2 + " : " + score1;
    }
    void SetPlayerPositions()
    {
        player1.ResetPosition();
        player2.ResetPosition();
        this.transform.position = new Vector2(0, 0);
        rb2d.velocity = new Vector2(0, 0);
    }
}
