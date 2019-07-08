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

    private float health;
    private int stamina;
    private Rigidbody2D rb2d;
    private PlayerController sprint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = speed;
        stamina = 100;
        health = 100f;
        
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

        HealthText.text = "Health: " + health;
        StaminaText.text = "Stamina: " + stamina;
        
        //keys.text = speed + ", ";
        ReplenishHealth();


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
        
        if (stamina > 0 )
        {
            speed = defaultSpeed + (defaultSpeed * (sprintPower * (int)sprint) * -1);
        }
        else {
            speed = defaultSpeed;
        }

        float moveHorizontal = Input.GetAxis(horizontal);
        float moveVertical = Input.GetAxis(vertical);

        if (sprint < 0 & (moveHorizontal >= 0.3 || moveVertical >= 0.3))
        {
            stamina -= 2;
        }

        if (stamina >= 100)
        {
            stamina = 100;
        }
        else if(!(sprint > 0))
        {
            stamina += 1;
        }
        if (stamina < 0)
        {
            stamina = 0;
        }
        
    }
    public void GetHit(float power)
    {
        health -= power;
    }

    public void ReplenishHealth()
    {
        if(health >= 100f)
        {
            health = 100f;
        }
        else if(health < 0f)
        {
            ResetPosition();
            health = 100f;
            
        }
        else
        {
            health += 0.01f;
        }
    }
   
    
}
