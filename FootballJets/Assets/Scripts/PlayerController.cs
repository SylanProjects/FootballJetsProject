using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerConfig playerConfig;
    
    public GlobalSettings globalSettings;
    public Text keys;
    
    
    public float deadZone;
    public Stats stats;
    public BusyState busyState;
    public CrosshairMouseControl body;

    private float speed;
    private float defaultSpeed;
    private Rigidbody2D rb2d;
    private PlayerController sprint;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = globalSettings.speed;
        speed = globalSettings.speed;
        

    }
    
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis (playerConfig.horizontalL);
        float moveVertical = Input.GetAxis (playerConfig.verticalL);
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
        this.transform.position = new Vector2(playerConfig.defaultXPos, playerConfig.defaultYPos);
        
    }

    private void Sprint()
    {
        // Get a key input 
        float sprint = Input.GetAxis(playerConfig.sprintKey);
        
        if (stats.GetStaminaStatus() > 0 )
        {
            speed = defaultSpeed + (defaultSpeed * (globalSettings.sprintPower * (int)sprint) * -1);
        }
        else {
            speed = defaultSpeed;
        }

        float moveHorizontal = Input.GetAxis(playerConfig.horizontalL);
        float moveVertical = Input.GetAxis(playerConfig.verticalL);

        bool movingHorizontal = moveHorizontal >= 0.3 || moveHorizontal <= -0.3;
        bool movingVertical = moveVertical >= 0.3 || moveVertical <= -0.3;

        if (sprint < 0 & (movingHorizontal || movingVertical))
        {
            //stats.stamina -= 2;
            stats.AddStamina(-2);
        }

        if (stats.GetStaminaStatus() >= 100)
        {
            stats.SetStamina(100);
        }
        else if(!(sprint > 0))
        {
            stats.AddStamina(1);
        }
        if (stats.GetStaminaStatus() < 0)
        {
            stats.SetStamina(0);
        }
        
    }
    public void GetHit(float power)
    {
        /*
         * To add randomness to the game and make it less predictable,
         * the power with which the player will be hit will be multiplied by a random 
         * number. 
         * The initial power with which the player is hit is dependant
         * on the item that hits it, e.g. a bullet or a sword.
         */
        power *= Random.Range(0.3f, 1.5f);
        stats.AddHealth(-power);
    }

    
   
    
}
