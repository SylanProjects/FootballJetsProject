using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;
    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
      direction = Vector2.one.normalized; // direction is (1, 1) normalized
      radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
      // Time.deltatime = adjust for changes in the framerate
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
          direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0) {
          direction.y = -direction.y;
        }

        // Game over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0) {
          Debug.Log("Right player has won!");
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0) {
          Debug.Log("Left player has won!");
        }



    }

    void OnTriggerEnter2D(Collider2D other) {
      // Rigidbody and Collider needed
      if (other.tag == "Player") {
        bool isRight = other.GetComponent<Player>().isRight;

        // If hitting the right paddle, flip direction
        if (isRight && direction.x > 0) {
          direction.x = -direction.x;
        }
        // If hitting the left paddle, flip direction
        if (isRight == false && direction.x < 0) {
          direction.x = -direction.x;
        }
      }
    }
}
