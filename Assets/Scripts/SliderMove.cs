using UnityEngine;

public class SliderPoint : MonoBehaviour
{
    public Transform slider; // Das Slider-GameObject
    public float speed = 5.0f; // Geschwindigkeit, mit der sich der Punkt bewegt
    private float sliderLength; // Länge des Sliders
    public float positionOnSlider = 0.5f; // Position auf dem Slider (0 bis 1)
    private GameObject player1; // Referenz auf Spieler 1
    private GameObject player2; // Referenz auf Spieler 2

    private void Start()
    {
        // Berechne die Länge des Sliders
        sliderLength = GetSliderLength();
        // Positioniere den Punkt bei 50% der Länge des Sliders
        transform.position = GetPointPosition(positionOnSlider);
    }

    private void Update()
    {
        // Spieler 1 bewegt den Punkt
        if (player1 != null && Input.GetKey(KeyCode.D)) // Bewegen nach rechts
        {
            positionOnSlider += speed * Time.deltaTime / sliderLength;
        }
        if (player1 != null && Input.GetKey(KeyCode.A)) // Bewegen nach links
        {
            positionOnSlider -= speed * Time.deltaTime / sliderLength;
        }

        // Spieler 2 bewegt den Punkt
        if (player2 != null && Input.GetKey(KeyCode.L)) // Bewegen nach rechts
        {
            positionOnSlider += speed * Time.deltaTime / sliderLength;
        }
        if (player2 != null && Input.GetKey(KeyCode.J)) // Bewegen nach links
        {
            positionOnSlider -= speed * Time.deltaTime / sliderLength;
        }

        // Begrenze die Position auf dem Slider auf den Bereich von 0 bis 1
        positionOnSlider = Mathf.Clamp01(positionOnSlider);

        // Aktualisiere die Position des Punktes basierend auf der Position auf dem Slider
        transform.position = GetPointPosition(positionOnSlider);
    }

    private float GetSliderLength()
    {
        // Berechne die Länge des Sliders
        return Vector3.Distance(slider.GetChild(0).position, slider.GetChild(1).position);
    }

    private Vector3 GetPointPosition(float normalizedPosition)
    {
        // Berechne die Position des Punktes basierend auf der normalisierten Position auf dem Slider
        return Vector3.Lerp(slider.GetChild(0).position, slider.GetChild(1).position, normalizedPosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Unterscheiden zwischen Spieler 1 und Spieler 2 anhand von Namen
            if (other.gameObject.name == "Player1")
            {
                player1 = other.gameObject;
            }
            else if (other.gameObject.name == "Player2")
            {
                player2 = other.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Unterscheiden zwischen Spieler 1 und Spieler 2 anhand von Namen
            if (other.gameObject.name == "Player1")
            {
                player1 = null;
            }
            else if (other.gameObject.name == "Player2")
            {
                player2 = null;
            }
        }
    }
}
