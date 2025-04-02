using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private float leftright;
    public float speed = 12f;
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
        animator.SetFloat("Speed", Mathf.Abs(leftright));

        if (Input.GetKeyDown("i") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
        }
        

        if (Input.GetKeyUp("i") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

        

        if (Input.GetKey("l") && Input.GetKey("j"))
        {
            leftright = 0f;
        }
        else if (Input.GetKey("l"))
        {
            leftright = 1f;
        }
        else if (Input.GetKey("j"))
        {
            leftright = -1f;
        }
        else
        {
            leftright = 0f;
        }



        if (!wasGrounded && isGrounded)
        {
            OnLanding();
        }

        wasGrounded = isGrounded;

        Flip();
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(leftright * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.3f, groundLayer);

        // Durchlaufe alle �berlappenden Collider
        foreach (Collider2D collider in colliders)
        {
            // �berpr�fe, ob der �berlappende Collider nicht der Spieler selbst ist
            if (collider.gameObject != gameObject)
            {
                return true; // Es wurde ein Boden gefunden, der nicht der Spieler ist
            }
        }

        return false; // Kein Boden gefunden
    }

    private void Flip()
    {
        if (isFacingRight && leftright < 0f || !isFacingRight && leftright > 0f)
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