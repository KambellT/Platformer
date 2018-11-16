using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statement to allow us to use the scene managment functions
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

        // get axis input from unity
        float leftRight = Input.GetAxis(horizontalAxis);
  
        // create direction vector for axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // make direction vector length 1
        direction = direction.normalized;

        // calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // give the velocity to the rigid body
        physicsBody.velocity = velocity;

        //tell the animator our speed
        playerAnimator.SetFloat("Walk Speed", Mathf.Abs(velocity.x));

        //flip our sprite if we're moving backwards
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        // jumping

        // detect if we are touching the ground
        // get the LayerMask from Unity using the name of the layer
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        // ask the player's collider if we are touching the LayerMask
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask); 

        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            // we have pressed jump, so we should set our 
            // upward velocity to our jumpSpeed
            velocity.y = jumpSpeed;

            // give the velocity to the rigibody
            physicsBody.velocity = velocity;
        }
     
    }

    // our own function for handling player death
    public void Kill()
    {

        // reset the current level to restart from the beginning

        // first, ask unity what the current level is
        Scene currentLevel = SceneManager.GetActiveScene();

        // second, tell unity to load the current again
        // by passing the build index of our level
        SceneManager.LoadScene(currentLevel.buildIndex); 


    }
       
}
