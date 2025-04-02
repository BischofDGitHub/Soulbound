using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool isPressed = false; // Status des Knopfes
    private Collider2D playerOnButton = null; // Der Spieler, der den Knopf betätigt
    public Vector3 pressedScale = new Vector3(3, 0.63f, 1); // Skalierung des Knopfes, wenn er gedrückt wird
    private Vector3 originalScale; // Originale Skalierung des Knopfes
    private Vector3 originalPosition; // Originale Position des Knopfes

    void Start()
    {
        originalScale = transform.localScale; // Originale Skalierung speichern
        originalPosition = transform.position; // Originale Position speichern
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = true;
            playerOnButton = other;
            Debug.Log("Button Pressed by " + other.gameObject.name);
            ShrinkButton();
            // Hier kannst du weitere Aktionen hinzufügen, die beim Drücken des Knopfes passieren sollen
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerOnButton)
        {
            isPressed = false;
            playerOnButton = null;
            Debug.Log("Button Released by " + other.gameObject.name);
            ResetButton();
            // Hier kannst du weitere Aktionen hinzufügen, die beim Loslassen des Knopfes passieren sollen
        }
    }

    void ShrinkButton()
    {
        float yOffset = (originalScale.y - pressedScale.y) / 2;
        transform.localScale = pressedScale; // Knopf schrumpfen
        // Position anpassen, damit die Unterseite des Knopfes an derselben Stelle bleibt
        transform.position = new Vector3(originalPosition.x, originalPosition.y - yOffset, originalPosition.z);
    }

    void ResetButton()
    {
        transform.localScale = originalScale; // Originale Skalierung wiederherstellen
        transform.position = originalPosition; // Originale Position wiederherstellen
    }
}
