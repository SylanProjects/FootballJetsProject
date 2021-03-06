﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            float x = collision.GetComponent<Rigidbody2D>().velocity.x;
            float y = collision.GetComponent<Rigidbody2D>().velocity.y;
            Vector2 force = new Vector2(x, y);
            collision.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}
