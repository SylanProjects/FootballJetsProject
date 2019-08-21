using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSizeControl : MonoBehaviour
{
    public Transform ball;
    public void Start()
    {
        float x = ball.transform.localScale.x * GameStartSettings.ballSize;
        float y = ball.transform.localScale.y * GameStartSettings.ballSize;

        ball.transform.localScale = new Vector2(x, y);
    }

}
