using TMPro;
using UnityEngine;

public class TopScoreCounter : MonoBehaviour
{
    // Gather the score from the usersspace.
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI topScoreUser;

    // Store the current top score in the private area.
    private float topScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create the data required for the game.
    }

    // Update is called once per frame
    void Update()
    {
        // If the users top score exist make sure to parse it and add it.
        if (PlayerPrefs.HasKey("TopScore"))
        {
            topScore = PlayerPrefs.GetFloat("TopScore");
        } else // Otherwise set it to zero.
        {
            topScore = 0;
        }

        // If the current score is larger then the last top score update the top score.
        if (topScore < float.Parse(currentScore.text))
        {
            // Update the top score.
            topScore = float.Parse(currentScore.text);
        }

        // Update the text of the game to reflect the top score.
        topScoreUser.text = topScore.ToString();

        // Update the current data locally on the devices.
        PlayerPrefs.SetFloat("TopScore", topScore);
    }
}
