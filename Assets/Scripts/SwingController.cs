using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for a left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            animator.SetTrigger("LeftSwingTrigger");
        }
    }
}
