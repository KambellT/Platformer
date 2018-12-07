using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this allows us to see the scene loading function
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{

    // this will be called by the Button component when the button is clicked
    public void StartGame()
    {
        // reset the score
        PlayerPrefs.DeleteKey("score");

        // reset the lives
        PlayerPrefs.DeleteKey("lives");

        // load the first level
        SceneManager.LoadScene("Level1");
    }
}
