using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player1; // Referenz auf den Spieler (oder ein anderes Objekt), dem die Kamera folgen soll
    [SerializeField] private Transform Player2;
    [SerializeField] private Vector3 offset; // Der Abstand zwischen Kamera und Spieler
    [SerializeField] private Camera cam;
    float aspectRatio = (float)Screen.width / Screen.height;
 
    

    void Start()
    {
        //offset = new Vector3(0, 0, -10f);
        cam.orthographicSize = 25;
        transform.position = new Vector3(50*aspectRatio/2, 25, -10);
    }

    void LateUpdate()
    {
        /*if(Player1 != null && Player2 != null)
        {
            cam.orthographicSize = Math.Abs(Math.Abs(Player1.position.x) - Math.Abs(Player2.position.x)) / 4 + 3;
            transform.position = (Player1.position + Player2.position) / 2 + offset;
        }
        else if (Player1 != null && Player2 == null)    
        {
            // Die Position der Kamera aktualisieren, um der Position des Spielers zu folgen
            cam.orthographicSize = 5;
            transform.position = Player1.position + offset;
        }
        else if (Player2 != null && Player1 == null)
        {
            cam.orthographicSize = 5;
            transform.position = Player2.position + offset; 
        }
        */
    }
}
    