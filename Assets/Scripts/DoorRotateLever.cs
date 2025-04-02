using UnityEngine;

public class DoorRotateLever : MonoBehaviour
{
    [SerializeField] private Transform startRotationTransform; // Startrotation Transform
    [SerializeField] private Transform endRotationTransform; // Zielrotation Transform
    [SerializeField] private LeverMove leverSkript; // Referenz zum LeverMove-Skript
    private Quaternion startRotation; // Startrotation
    private Quaternion endRotation; // Zielrotation
    public float duration = 2.0f; // Dauer der Bewegung in Sekunden
    private float timeElapsed = 2.0f;
    private bool active = false;

    void Start()
    {
        // Initialisieren der Start- und Endrotation basierend auf den Transform-Rotationen
        startRotation = startRotationTransform.rotation;
        endRotation = endRotationTransform.rotation;
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
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.rotation = endRotation;
            timeElapsed = duration; // sicherstellen, dass timeElapsed nicht weiter erhöht wird
        }
    }

    void LeverInactive()
    {
        if (timeElapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(endRotation, startRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.rotation = startRotation;
            timeElapsed = duration; // sicherstellen, dass timeElapsed nicht weiter erhöht wird
        }
    }
}
