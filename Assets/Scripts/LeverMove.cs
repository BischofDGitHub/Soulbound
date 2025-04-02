using UnityEngine;

public class LeverMove : MonoBehaviour
{
    public Transform pivot; // Das Parent-Transform, um das der Hebel rotiert
    public float rotationSpeed = 50f; // Rotationsgeschwindigkeit
    public float maxRotationAngle = 35f; // Maximale Rotation in eine Richtung
    public KeyCode player1KeyLeft = KeyCode.A; // Taste für Spieler 1 nach links
    public KeyCode player1KeyRight = KeyCode.D; // Taste für Spieler 1 nach rechts
    public KeyCode player2KeyLeft = KeyCode.J; // Taste für Spieler 2 nach links
    public KeyCode player2KeyRight = KeyCode.L; // Taste für Spieler 2 nach rechts
    private bool isPlayer1Near = false; // Überprüft, ob Spieler 1 in der Nähe ist
    private bool isPlayer2Near = false; // Überprüft, ob Spieler 2 in der Nähe ist
    public float rotationAngle = -35f; // Aktueller Rotationswinkel

    void Update()
    {
        if (isPlayer1Near && Input.GetKey(player1KeyRight))
        {
            RotateLever(-1);
        }
        else if (isPlayer1Near && Input.GetKey(player1KeyLeft))
        {
            RotateLever(1);
        }
        else if (isPlayer2Near && Input.GetKey(player2KeyRight))
        {
            RotateLever(-1);
        }
        else if (isPlayer2Near && Input.GetKey(player2KeyLeft))
        {
            RotateLever(1);
        }
        //else
        //{
        //    ReturnLever();
        //}
    }

    void RotateLever(int direction)
    {
        float newRotationAngle = rotationAngle + direction * rotationSpeed * Time.deltaTime;
        newRotationAngle = Mathf.Clamp(newRotationAngle, -maxRotationAngle, maxRotationAngle);

        float rotationDelta = newRotationAngle - rotationAngle;
        transform.RotateAround(pivot.position, Vector3.forward, rotationDelta);
        rotationAngle = newRotationAngle;
    }

    void ReturnLever()
    {
        float returnSpeed = rotationSpeed * Time.deltaTime;
        if (rotationAngle > 0)
        {
            rotationAngle -= returnSpeed;
            if (rotationAngle < 0) rotationAngle = 0;
        }
        else if (rotationAngle < 0)
        {
            rotationAngle += returnSpeed;
            if (rotationAngle > 0) rotationAngle = 0;
        }

        float rotationDelta = -returnSpeed * Mathf.Sign(rotationAngle);
        transform.RotateAround(pivot.position, Vector3.forward, rotationDelta);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Unterscheiden zwischen Spieler 1 und Spieler 2 anhand von Namen oder Tags
            if (other.gameObject.name == "Player1")
            {
                isPlayer1Near = true;
            }
            else if (other.gameObject.name == "Player2")
            {
                isPlayer2Near = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            // Unterscheiden zwischen Spieler 1 und Spieler 2 anhand von Namen oder Tags
            if (other.gameObject.name == "Player1")
            {
                isPlayer1Near = false;
            }
            else if (other.gameObject.name == "Player2")
            {
                isPlayer2Near = false;
            }
        }
    }

    public bool ActiveState()
    {
        return rotationAngle > 0;
    }
}
