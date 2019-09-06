using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerConfig playerConfig;
    public GlobalSettings globalSettings;
    public Stats stats;
    public BusyState busyState;
    public CrosshairMouseControl body;
    public TeamController team;
    public PlayerMovement playerMovement;
    private Rigidbody2D rb2d;


    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
