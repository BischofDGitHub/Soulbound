using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rb;
    private Transform target;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FindNearestPlayer();
        if (target != null)
        {
            float horizontal = (target.position - transform.position).normalized.x;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            Flip(horizontal);
        }
    }

    private void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject player in players)
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    target = player.transform;
                }
            }
        }
        else
        {
            target = null;
        }
    }

    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
