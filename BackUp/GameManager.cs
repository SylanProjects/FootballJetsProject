using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Player player;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;


    // Start is called before the first frame update
    void Start()
    {
      // Convert screen's pixel coordinate into game's coordinate (in this case 0, 0)
      bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
      topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

      // Create ball
      Instantiate(ball);
      // Create two paddles
      // Casting in C#
      Player player1 = Instantiate(player) as Player;
      //Player player2 = Instantiate(player) as Player;
      player1.Init(true); // right paddle
      //player2.Init(false); // left paddle
    }

}
