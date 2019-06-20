using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;

    private Rigidbody2D rb2d;

    private PlayerController sprint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = speed;
         
    }
    
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        float sprint = Input.GetAxis("Sprint");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        
        if (sprint < 0 )
        {
            speed = defaultSpeed + 4;
        }
        else if ( sprint >= 0 ) {
            speed = defaultSpeed;
        }

        


    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp")) {
            other.gameObject.SetActive (false);
        }
    }
}
