using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Sword : MonoBehaviour
{
    public PlayerController playerController;
    public Transform player;
    
    public Rigidbody2D ballRB2D;

    public PlayerRotator playerRotation;
    public Weapon weapon;
    public SwordSprite swordSprite;
    




    // Start is called before the first frame update
    void Start()
    {
        //  rb.velocity = transform.right * speed;
        this.transform.localScale = new Vector2(0, 0);
        swordSprite.gameObject.SetActive(false);

    }
    private void Update()
    {
        

        if (this.transform.localPosition.x > 0 && this.transform.localPosition.x <= 3)
        {
            Push();
        }
        
        
    }
    public void UseSword()
    {
        if (!playerController.busyState.GetState())
        {

            weapon.ShowCurrentWeapon(false);
            swordSprite.gameObject.SetActive(true);
            playerController.body.Pullback(0.4f);
            playerController.busyState.SetState(true);
            Push();

        }
    }

    private void Push()
    {
        /*
         * This function creates an invisible collider and pushes it in front of the player, 
         * this "push" is needed to create velocity so when it collides with the ball
         * it will push it back. The force (bounciness) with which it pushes the ball can be configured in the 
         * 'Physics' folder, in the file 'Sword'. 
         * To make sure the ball is only pushed when it is infront of the player, 
         * or when it is in the hit area.
         */
        float x = this.transform.localPosition.x;
        float y = this.transform.localPosition.y;
        this.transform.localPosition = new Vector2(x + 0.6f, y);
        x = this.transform.localScale.x;
        this.transform.localScale = new Vector2(x+2f, 0);
        if (this.transform.localPosition.x >= 3)
        {
            this.transform.localPosition = new Vector2(0, 0);
            this.transform.localScale = new Vector2(0, 0);
            playerController.busyState.SetState(false);
            weapon.ShowCurrentWeapon(true);
            swordSprite.gameObject.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ball"))
        {
            Bounce(collision, playerController.globalSettings.swordStrength);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce(collision, 200);
            collision.gameObject.GetComponent<PlayerController>().GetHit(5);
        }


    }
    void Bounce(Collider2D collision, float strength)
    {

        Vector2 rotation = playerRotation.GetRotation().GetVector();
        collision.attachedRigidbody.AddForce(rotation * strength);
    }


}
