using System;
using UnityEngine;

public class BallHitter : MonoBehaviour
{
    public Animator animator; // Reference to the Animator

    public GameObject ball; // Reference to the ball object
    private bool isSwinging = false; // To track if the user is currently swingin

    public float slope = 2;

    public float upAngle = -30f;

    private bool didHitBall = false;
    private float animationProgress;

    void Start() {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    
    // Update method to detect the mouse input
    void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        isSwinging = stateInfo.IsName("LeftSwing");

        if (isSwinging)
        {
            // Debug.Log("swinging...");
            animationProgress = stateInfo.normalizedTime; // Check animation progress as a percentage
            if (animationProgress >= 1) {
                isSwinging = false;
                didHitBall = false;
            }
        }
    }

    // OnTriggerStay to detect when the ball is within the swing collider
    private void OnTriggerStay(Collider other)
    {
        if (isSwinging && !didHitBall && other.gameObject == ball) 
        {
            didHitBall = true;

            // Calculate the angle adjustment based on inverted timing
            float angleAdjustment = Mathf.Lerp(-20f, 20f, 1-slope*animationProgress);
            // Debug.Log($"animProg: {animationProgress}");
            // Debug.Log($"f(x): {1-slope*animationProgress}");
            // Debug.Log("Angle Adjustment: " + angleAdjustment);
            // Calculate direction vector
            Vector3 direction = Quaternion.Euler(0, angleAdjustment, upAngle) * Vector3.left;
            
            // Apply the calculated direction to the ball (assuming a Rigidbody component)
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            ballRb.velocity = direction * ballRb.velocity.magnitude; // Preserve ball's speed, change direction
        }
    }
}
