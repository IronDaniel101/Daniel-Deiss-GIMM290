using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISpeedBoostable
{
    public float speed = 5f;  // Adjust the speed as needed
    public float gravity = 9.8f;  // Adjust the gravity strength as needed
    public float jumpHeight = 3f;  // Adjust the jump height as needed
    private Vector3 velocity;
    private CharacterController characterController;
    public PlayerOneScore playerOneScore;
    public LayerMask groundLayer;
    public float sphereRadius = 2f;


    private ControllerColliderHit contact;
    //Interacting with moveable Objects
    public float pushForce = 3.0f;



    public bool canScore = true; // Flag to control scoring cooldown
    public float scoreCooldown = 1f; // Cooldown duration in seconds
    

    //Speed Boost Addition 
    public float speedBoostAmount = 2f; // Adjust the speed boost factor as needed
    public bool isSpeedBoosted = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        // Perform raycast to check if there's a character below
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.Log("Ray cast hit: " + hit.collider.gameObject.name);

            // Assuming the character below has a tag "Player"
            if (hit.collider.CompareTag("Player") && canScore)
            {
                // If a character is detected below, increase the score
                playerOneScore.IncreaseScore();
                canScore = false;
                //Add a delay before scoring is allowed again
                StartCoroutine(ResetScoringCooldown(scoreCooldown));
            }
        }

        
        DebugDrawRayCast(transform.position, Vector3.down, 5f, Color.red);

        // Get input from the arrow keys or WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Add gravity to the movement vector
        movement += velocity * Time.deltaTime;

        // Apply movement to the player using CharacterController
        characterController.Move(movement);

        // Check if the player is on the ground
        if (characterController.isGrounded)
        {
            // If on the ground, reset the Y velocity and allow jumping
            velocity.y = -0.5f;  // You can set a small negative value to help with slight ground adjustments

            // Check for jump input
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Apply an upward force for jumping
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
        }
    }

    public void ApplySpeedBoost(float boostAmount)
    {
        // Apply the speed boost
        speed *= boostAmount;
        isSpeedBoosted = true;

        // You can add a timer or other logic to handle the duration of the speed boost
        // For simplicity, let's assume a 5-second duration
        StartCoroutine(ResetSpeedBoostAfterDelay(5f));
    }

    IEnumerator ResetSpeedBoostAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reset speed to the base speed after the specified delay
        speed /= speedBoostAmount;
        isSpeedBoosted = false;
    }

    IEnumerator ResetScoringCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        canScore = true;
    }

    void DebugDrawRayCast(Vector3 origin, Vector3 direction, float length, Color color)
    {
        Debug.DrawRay(origin, direction * length, color);
    }


    // store collision to use in Update
	void OnControllerColliderHit(ControllerColliderHit hit) {
		contact = hit;
		
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic) {
			body.velocity = hit.moveDirection * pushForce;
		}
	}
}
