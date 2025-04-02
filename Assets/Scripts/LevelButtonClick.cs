using UnityEngine;
using UnityEngine.UI;

public class ButtonLoadScene : MonoBehaviour
{
    private ChangeScene changeScene;

    void Start()
    {
        // Finde das ChangeScene-Skript im Spielobjekt (z.B. dem GameManager)
        changeScene = FindObjectOfType<ChangeScene>();

        // Stelle sicher, dass das ChangeScene-Skript gefunden wurde
        if (changeScene == null)
        {
            Debug.LogError("ChangeScene script not found in the scene.");
            return;
        }

        // Hole den Button-Component und füge den OnClick-Listener hinzu
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClicked(button.name));
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }

    void OnButtonClicked(string buttonName)
    {
        // Rufe die LoadScene-Methode auf und übergebe den Button-Namen
        changeScene.LoadScene(buttonName);
    }
}
