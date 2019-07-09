using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public float sprintPower;
    public string horizontal;
    public string vertical;
    public string sprintKey;
    public int defaultXPos;
    public int defaultYPos;
    public Text keys;
    public Text StaminaText;
    public Text HealthText;
    public float deadZone;
    public Stats stats;

    //private float health;
    //private int stamina;
    private Rigidbody2D rb2d;
    private PlayerController sprint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = speed;
       // stamina = 100;
       // health = 100f;
        
    }
    
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis (horizontal);
        float moveVertical = Input.GetAxis (vertical);
        float h = moveHorizontal;
        float v = moveVertical;
        if (moveHorizontal < deadZone && moveHorizontal > -deadZone)
        {
            h = 0;
            
        }
        if(moveVertical < deadZone && moveVertical > -deadZone)
        {
            v = 0;
        }
        
        

        Vector2 movement = new Vector2(h, v);
        

        rb2d.AddForce(movement * speed);
        Sprint();

        
        
        //keys.text = speed + ", ";
        //ReplenishHealth();


    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp")) {
            other.gameObject.SetActive (false);
        }
        


    }
    public void ResetPosition()
    {
        rb2d.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(defaultXPos, defaultYPos);
        
    }

    private void Sprint()
    {
        // Get a key input 
        float sprint = Input.GetAxis(sprintKey);
        
        if (stats.stamina > 0 )
        {
            speed = defaultSpeed + (defaultSpeed * (sprintPower * (int)sprint) * -1);
        }
        else {
            speed = defaultSpeed;
        }

        float moveHorizontal = Input.GetAxis(horizontal);
        float moveVertical = Input.GetAxis(vertical);

        bool movingHorizontal = moveHorizontal >= 0.3 || moveHorizontal <= -0.3;
        bool movingVertical = moveVertical >= 0.3 || moveVertical <= -0.3;

        if (sprint < 0 & (movingHorizontal || movingVertical))
        {
            stats.stamina -= 2;
        }

        if (stats.stamina >= 100)
        {
            stats.stamina = 100;
        }
        else if(!(sprint > 0))
        {
            stats.stamina += 1;
        }
        if (stats.stamina < 0)
        {
            stats.stamina = 0;
        }
        
    }
    public void GetHit(float power)
    {
        stats.health -= power;
    }

    
   
    
}
