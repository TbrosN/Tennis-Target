using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera in the Inspector
    private float distanceFromCamera; // The distance from the camera to the racket in Z axis
    private float fixedXPosition; // The X position of the racket in the Y-Z plane
    void Start()
    {
        // If mainCamera is not assigned, automatically find the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Set fixedXPosition to the current X position of the racketTop at the start
        fixedXPosition = transform.position.x;
        distanceFromCamera = Math.Abs(transform.position.x - mainCamera.transform.position.x);
    }

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = distanceFromCamera; // Set the Z distance from the camera (3D depth)

        // Convert the mouse position to world space using the camera
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Move the entire racketTop (now the parent) so it follows the mouse
        transform.position = new Vector3(
            fixedXPosition, 
            worldMousePosition.y, 
            worldMousePosition.z
        );

        // Align the top with the mouse (keeps the racket aligned in Y-Z plane)
        // Vector3 direction = new Vector3(0, worldMousePosition.y - transform.position.y, worldMousePosition.z - transform.position.z);
        // transform.up = direction;
    }
}
