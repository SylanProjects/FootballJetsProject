using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //public PlayerController player1;
    //public PlayerController player2; 
    private GameObject redTeam, blueTeam;
    
   // public Text scoreText;
    public Rigidbody2D rb;
    //public Stats player1Stats;
    //public Stats player2Stats;
    


    private Rigidbody2D rb2d;
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb.mass = GameStartSettings.ballWeight;
        redTeam = GameObject.Find("RedTeam");
        blueTeam = GameObject.Find("BlueTeam");
    }

    void Update()
    {
        if (Input.GetButton("Reset"))
        {
            ResetPlayers();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftGoal"))
        {

            redTeam.GetComponent<TeamController>().AddPoint(1);
            ResetPlayers();
            
        }
        if (other.gameObject.CompareTag("RightGoal"))
        {
            
            blueTeam.GetComponent<TeamController>().AddPoint(1);
            ResetPlayers();
           

        }
    }
    
    void ResetPlayers()
    {   
        this.transform.position = new Vector2(0, 0);
        rb2d.velocity = new Vector2(0, 0);
        redTeam.GetComponent<TeamController>().ResetPlayers();
        blueTeam.GetComponent<TeamController>().ResetPlayers();
    }

    public void Bounce()
    {
        /* The ball should bounce by itself but this is the manual 
         * overwrite. 
         */
        rb2d.AddForce(-rb2d.velocity);
    }
}
