using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statement to allow us to use the scene managment functions
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour {

    // designer variables
    public string sceneToLoad;

    // unity calls this function automatically
    // when our spikes touch any other object
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // check if the thing we collided with
        // is the player (aka has a Player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        // only do something if the thing we ran into
        // was in fact the player
        // aka playerScript is not null
        if (playerScript != null)
        {
            // we DID hit the player!

            // load the next level
            SceneManager.LoadScene(sceneToLoad); 
          
        }

    }
}
