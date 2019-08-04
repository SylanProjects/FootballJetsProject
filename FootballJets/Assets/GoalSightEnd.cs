using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSightEnd : MonoBehaviour
{
    public AIController aiController;
    private GameObject player, goal;
    public void Start()
    {
        player = aiController.opponent;
        goal = aiController.GetOppositeGoal();
        
    }
    public void Update()
    {

        this.transform.position = new Vector2(0, 0);
    }
}
