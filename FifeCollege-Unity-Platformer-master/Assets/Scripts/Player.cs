using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra using statement to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);

        // Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Give the velocity to the rigidbody
        physicsBody.velocity = velocity;


        // Tell the animator our speed
        playerAnimator.SetFloat("walkSpeed", Mathf.Abs(velocity.x) );

        // Flip our sprite if we're moving backward
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }


        // Jumping

        // Detect if we are touching the ground
        // Get the LayerMask from Unity using the name of the layer
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        // Ask the player's collider if we are touching the LayerMask
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            // We have pressed jump, so we should set our
            // upward velocity to our jumpSpeed
            velocity.y = jumpSpeed;

            // Give the velocity to the rigidbody
            physicsBody.velocity = velocity;
        }


    }
    

    // Our own function for handling player death
    public void Kill()
    {

        // Reset the current level to restart from the beginning.

        // First, ask unity what the current level is
        Scene currentLevel = SceneManager.GetActiveScene();

        // Second, tell unity to load the current again
        // by passing the build index of our level
        SceneManager.LoadScene(currentLevel.buildIndex);

    }

}
