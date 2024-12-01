using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera in the Inspector
    public float tiltAngle = 15f; // The amount of tilt (in degrees) when racket is on left or right side

    void Start()
    {
        // If mainCamera is not assigned, automatically find the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Determine if the racket is on the left or right side of the screen
        Vector3 racketScreenPosition = mainCamera.WorldToScreenPoint(transform.position);
        float screenWidth = Screen.width;
        float screenCenter = screenWidth / 2f;

        // if (racketScreenPosition.x > screenCenter)
        // {
        //     // Right half of the screen: tilt right by the tiltAngle
        //     transform.localRotation = Quaternion.Euler(tiltAngle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        // }
        // else
        // {
        //     // Left half of the screen: tilt left by the tiltAngle
        //     transform.localRotation = Quaternion.Euler(-tiltAngle, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        // }
    }
}
