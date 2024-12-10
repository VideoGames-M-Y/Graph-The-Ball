using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFalling = false;  // Flag to check if the ball should fall

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
        rb.isKinematic = true;  // Disable physics initially
    }

    void Update()
    {
        // If the ball should fall, enable gravity
        if (isFalling)
        {
            rb.isKinematic = false;  // Enable physics
            rb.useGravity = true;  // Enable gravity for the fall
        }
    }

    // This method will be called when the function is submitted
    public void StartFalling()
    {
        isFalling = true;
    }
}