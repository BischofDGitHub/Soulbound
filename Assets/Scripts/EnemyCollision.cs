using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement1 playerMovement1; // Referenz zum PlayerMovement1-Skript
    [SerializeField] private PlayerMovement2 playerMovement2; // Referenz zum PlayerMovement1-Skript


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            animator.SetBool("IsDying", true);
            playerMovement1.enabled = false; // Deaktiviert das PlayerMovement1-Skript
            playerMovement2.enabled = false;
            Death();
        }
    }

    private void Death()
    {
        GetComponent<ChangeScene>().ReloadScene();
    }
}
