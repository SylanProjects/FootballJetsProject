using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.gameObject.CompareTag("Ball"))
        {
            
            collision.attachedRigidbody.AddForce(rb.velocity);
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(20); ;
        }
        Destroy(gameObject);
    }


}
