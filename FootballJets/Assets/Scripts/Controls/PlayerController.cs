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
    public TeamController team;

    private bool movingHorizontal = true;
    private bool movingVertical = true;

    private float speed;
    private float defaultSpeed;
    private Rigidbody2D rb2d;
    private PlayerController sprint;
    private bool sprinting;
    private bool recharging;


    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = GameStartSettings.playerSpeed;
        speed = GameStartSettings.playerSpeed;
        sprinting = false;
        recharging = false;

    }
    public void FixedUpdate()
    {
        // Drain stamina if sprinting and regenerate if not 
        if (sprinting && (movingHorizontal || movingVertical) )
        {
            stats.AddStamina(-globalSettings.staminaDrain);
        }
        else if (!sprinting || !(movingHorizontal || movingVertical))
        {
            stats.AddStamina(globalSettings.staminaRecharge);
        }

        if (stats.GetStaminaStatus() >= GameStartSettings.stamina)
        {
            stats.SetStamina(GameStartSettings.stamina);
            recharging = false;
        }
        
        if (stats.GetStaminaStatus() < 0)
        {
            stats.SetStamina(0);
            recharging = true;
        }  
    }

    public void MovePlayer(float moveHorizontal, float moveVertical)
    {
        /* moveHorizontal and moveVertical would be a vector line in the wanted
         * direction. Joystick X and Y axis are used to get the vectors. Keyboard
         * arrows could also be used to get that information. 
         * Deadzone is used to avoid moving the character with a very 
         * small movement of the joystick.
         */
        
        float h = moveHorizontal;
        float v = moveVertical;
        if (moveHorizontal < deadZone && moveHorizontal > -deadZone)
        {
            h = 0;
            movingHorizontal = false;
        }
        else
        {
            movingHorizontal = true;

        }

        if (moveVertical < deadZone && moveVertical > -deadZone)
        {
            v = 0;
            movingVertical = false;
        }
        else
        {
            movingVertical = true;
        }

        Vector2 movement = new Vector2(h, v);
        rb2d.AddForce(movement * speed * Time.deltaTime); 
    }

    public void Sprint(float sprint)
    {
        /* Only sprint if there is a stamina.
         * Sprint just changes the speed variable which is used to calculate the force
         * with which the player should move in the movePlayer method.
         */
        if(sprint != 0)
        {
            if (stats.GetStaminaStatus() > 0 && !recharging)
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
        // Velocity has to be set to zero to stop object from moving when it changes the position
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
    public void ResetHealth()
    {
        stats.AddHealth(GameStartSettings.health);
    }
    public GlobalSettings GetGlobalSettings()
    {
        return this.globalSettings;
    }
}
