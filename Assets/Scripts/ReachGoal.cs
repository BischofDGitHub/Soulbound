using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachGoal : MonoBehaviour
{
    [SerializeField] private Transform Goal;
    [SerializeField] private LayerMask Player;
    [SerializeField] private Collider2D Player1;
    //[SerializeField] private Collider2D Player2;


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // �berpr�fen, ob der Spieler den Trigger betritt
    //    if (other.CompareTag("Player")) 
    //    {
    //        Goal.position.y = 10;
    //    }
    //}

    void Update()
    {
        if (GoalReached())
        {
            GetComponent<ChangeScene>().LoadScene("Main_Menu");
            //Goal.position = new Vector2(Goal.position.x, 10);
        }


    }

    private bool GoalReached()
    {
        /*if (Player1 != null && Player2 != null)
        {
            if (Physics2D.OverlapCircle(Goal.position, 0.5f) == Player1)
            {
                return true;
            }
            
            if (Physics2D.OverlapCircle(Goal.position, 0.5f) == Player2)
            {
                return true;
            }
        }*/
        if (Player1 != null)
        {
            if (Physics2D.OverlapCircle(Goal.position, 0.5f) == Player1)
            {
                return true;
            }

        }
        return false;
    }
}
