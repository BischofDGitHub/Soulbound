using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;
    private bool wasGrounded; // Speichert den vorherigen Bodenkontaktstatus
    private bool isGrounded; // Speichert den aktuellen Bodenkontaktstatus

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Animator animator;


    void Start()
    {
        transform.position = SpawnPoint.position;
    }

    void Update()
    {
        isGrounded = IsGrounded();

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyUp("w") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            horizontal = 0f;
        }
        else if (Input.GetKey("d"))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey("a"))
        {
            horizontal = -1f;
        }
        else
        {
            horizontal = 0f;
        }

        Flip();

        // Überprüfen, ob der Spieler gerade gelandet ist
        if (!wasGrounded && isGrounded)
        {
            OnLanding();
        }

        // Aktualisiere den vorherigen Bodenkontaktstatus
        wasGrounded = isGrounded;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.3f, groundLayer);

        // Durchlaufe alle überlappenden Collider
        foreach (Collider2D collider in colliders)
        {
            // Überprüfe, ob der überlappende Collider nicht der Spieler selbst ist
            if (collider.gameObject != gameObject)
            {
                return true; // Es wurde ein Boden gefunden, der nicht der Spieler ist
            }
        }

        return false; // Kein Boden gefunden
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
