using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public float sprintN;

    private Rigidbody2D rb2d;
    private int count;
    private PlayerController sprint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        defaultSpeed = speed;
         
    }
    
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis ("Horizontal2");
        float moveVertical = Input.GetAxis ("Vertical2");
        
        float sprint = Input.GetAxis("Sprint");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        
        if (sprint < 0 )
        {
            speed = defaultSpeed + sprintN;
        }
        else if ( sprint >= 0 ) {
            speed = defaultSpeed;
        }

        


    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp")) {
            other.gameObject.SetActive (false);
            count += 10;
        }
    }

    public void ResetPosition()
    {
        this.transform.position = new Vector2(20, 0);
    }
}
