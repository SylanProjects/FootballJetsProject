using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2; 
    
    public Text scoreText;
    public Rigidbody2D rb;
    public Stats player1Stats;
    public Stats player2Stats;
    


    private Rigidbody2D rb2d;
   
    // Start is called before the first frame update
   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Reset"))
        {
            SetPlayerPositions();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftGoal"))
        {

            player2.team.AddGoal(1);
            SetPlayerPositions();
            
        }
        if (other.gameObject.CompareTag("RightGoal"))
        {
            
            player1.team.AddGoal(1);
            SetPlayerPositions();
           

        }
    }
    
    void SetPlayerPositions()
    {
        
        this.transform.position = new Vector2(0, 0);
        rb2d.velocity = new Vector2(0, 0);
        player1.ResetPosition();
        player2.ResetPosition();
    }

    public void Bounce()
    {
        rb2d.AddForce(-rb2d.velocity);
    }
}
