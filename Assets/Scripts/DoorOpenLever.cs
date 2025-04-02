using UnityEngine;

public class DoorOpenLever : MonoBehaviour
{
    [SerializeField] private Transform startPositionTransform; // Startposition Transform
    [SerializeField] private Transform endPositionTransform; // Zielposition Transform
    [SerializeField] private LeverMove leverSkript; // Referenz zum LeverMove-Skript
    private Vector3 startPosition; // Startposition
    private Vector3 endPosition; // Zielposition
    public float duration = 2.0f; // Dauer der Bewegung in Sekunden
    private float timeElapsed = 2.0f;
    private bool active = false;

    void Start()
    {
        // Initialisieren der Start- und Endposition basierend auf den Transform-Positionen
        startPosition = startPositionTransform.position;
        endPosition = endPositionTransform.position;
    }

    void Update()
    {
        // Rotation des Hebels überprüfen
        if (leverSkript != null)
        {
            bool leverActive = leverSkript.ActiveState();

            if (leverActive != active)
            {
                // Status hat sich geändert, Zeit umkehren
                timeElapsed = duration - timeElapsed;
                active = leverActive;
            }

            if (active)
            {
                LeverActive();
            }
            else
            {
                LeverInactive();
            }
        }
    }

    void LeverActive()
    {
        if (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = endPosition;
            timeElapsed = duration; // sicherstellen, dass timeElapsed nicht weiter erhöht wird
        }
    }

    void LeverInactive()
    {
        if (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = startPosition;
            timeElapsed = duration; // sicherstellen, dass timeElapsed nicht weiter erhöht wird
        }
    }
}
