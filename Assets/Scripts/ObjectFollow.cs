using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{

    [SerializeField] private Transform Object;


    void Update()
    {
        transform.rotation = Object.rotation;
        transform.position = Object.position;
    }
}

