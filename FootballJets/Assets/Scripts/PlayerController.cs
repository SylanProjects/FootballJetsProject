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

    private bool movingHorizontal = true;
    private bool movingVertical = true;

    private float speed;
    private float defaultSpeed;
    private Rigidbody2D rb2d;
    private PlayerController sprint;
    private bool sprinting;

    

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = globalSettings.speed;
        speed = globalSettings.speed;
        sprinting = false;

    }
    public void FixedUpdate()
    {
        
        
        if (sprinting && (movingHorizontal || movingVertical) )
        {
            stats.AddStamina(-globalSettings.staminaDrain);
        }
        else if (!sprinting || !(movingHorizontal || movingVertical))
        {
            stats.AddStamina(globalSettings.staminaRecharge);
        }
        if (stats.GetStaminaStatus() >= 100)
        {
            stats.SetStamina(100);
        }
        
        if (stats.GetStaminaStatus() < 0)
        {
            stats.SetStamina(0);
        }
        
        
        
        
    }

    public void MovePlayer(float moveHorizontal, float moveVertical)
    {
        
        float h = moveHorizontal;
        float v = moveVertical;

        
        

        if (moveHorizontal < deadZone && moveHorizontal > -deadZone)
        {
            h = 0;
            movingHorizontal = false;
        }else
        {
            movingHorizontal = true;
        }

        if (moveVertical < deadZone && moveVertical > -deadZone)
        {
            v = 0;
            movingVertical = false;
        }else
        {
            movingVertical = true;
        }

        Vector2 movement = new Vector2(h, v);
        rb2d.AddForce(movement * speed); 

    }

   
    public void Sprint(float sprint)
    {
        if(sprint != 0)
        {
            if (stats.GetStaminaStatus() > 0)
            {
                SetSprintingStatus(true);
                speed = defaultSpeed + (defaultSpeed * (globalSettings.sprintPower * (int)sprint) * -1);
            }
            else
            {
                speed = defaultSpeed;
            }
        }
        else
        {
            SetSprintingStatus(false);
        }
        
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

   
    public void SetSprintingStatus(bool status)
    {
        sprinting = status;
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
