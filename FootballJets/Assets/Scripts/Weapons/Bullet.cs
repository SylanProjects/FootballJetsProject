using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float strength;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Bounce(collision);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(strength);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("LeftGoal") || collision.gameObject.CompareTag("RightGoal"))
        {
            Destroy(gameObject);
        }
    }
    void Bounce(Collider2D collision)
    {
        // Push the given object 
        float x = rb.velocity.x * (strength / 100);
        float y = rb.velocity.y * (strength / 100);
        Vector2 force = new Vector2(x, y);
        collision.attachedRigidbody.AddForce(force);
    }


}
