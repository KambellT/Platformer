using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// needed for working with text components
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

    // text components used to display the highscores
    public List<Text> highScoreDisplays = new List<Text>();

    // internal data for score values
    private List<int> highScoreData = new List<int>(); 

	// Use this for initialization
	void Start () 
        {
        // load the high score data from the PlayerPrefs
        LoadHighScoredata();

        // update the visual display
        UpdateVisualDisplay();

    }
		
	
	
	// Update is called once per frame
	void Update () {
		
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
}
