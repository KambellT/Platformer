using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// needed for working with text components
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{

    // text components used to display the highscores
    public List<Text> highScoreDisplays = new List<Text>();

    // internal data for score values
    private List<int> highScoreData = new List<int>();

    // Use this for initialization
    void Start()
    {
        // load the high score data from the PlayerPrefs
        LoadHighScoredata();

        // get our current score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        // check if we got a new highscore
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)
        {
            // add new score to the data
            AddScoreToList(currentScore);


            // save updated data
            SaveHighScoredata();

        }

        // update the visual display
        UpdateVisualDisplay();

    }



    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighScoredata()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "highscore" + i.ToString();

            // use this key to get the high score value from the PlayerPrefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            // store this score value in our internal data list
            highScoreData.Add(highScoreValue);
        }
    }

    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // find the specific text and numbers in our list and set the text to the numerical score
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {
        // loop through the high scores and see if ours is higher than any of them
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // is our score higher than the high score we're checking this loop?
            if (scoreToCheck > highScoreData[i])
            {
                // our score is higher!
                // return to the calling code that we Do have a new high score
                return true;
            }
        }

        // default: false
        // we did NOT find any scores that our score was higher than...
        return false;
    }

    private void AddScoreToList(int newScore)
    {
        // loop through the high scores and find where the new score fits
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // is our score higher than the score we're checking in the list?
            if (newScore > highScoreData[i])
            {
                // our score IS higher
                // since we're going from highest to lowest, the first
                // time our score is higher, this is where it must go

                // insert the new score into the list here
                highScoreData.Insert(i, newScore);

                // trim the last item off the list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                // we're done, we must exit early
                return;

            }

        }
    }

    private void SaveHighScoredata()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "highscore" + i.ToString();

            // get the current hgih score entry from the data
            int highScoreEntry = highScoreData[i];

            // save this data to the PlayerPrefs
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
        }

        // save the player prefs to disk
        PlayerPrefs.Save();
    }

}



