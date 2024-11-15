using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;  // Speed at which the player moves
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

        private void Update()
    {

        // Get input from WASD or Arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow keys
        float verticalInput = Input.GetAxis("Vertical");      // W/S or Up/Down arrow keys

        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, 1);

        // Move the player based on the input and speed
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        // playerRb.velocity = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;
    }
}
