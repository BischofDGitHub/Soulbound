using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    public void vChange()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed screen mode");
    }
}
