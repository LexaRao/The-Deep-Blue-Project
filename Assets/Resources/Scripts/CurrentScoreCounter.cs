using TMPro;
using UnityEngine;

public class CurrentScoreCounter : MonoBehaviour
{
    // Create a current score variable.
    private string currentScore = "0";
    private float score = 0;

    // Initalize the textMeshPro text.
    public TextMeshProUGUI scoreCounter;

    // Create the required import for the reward sound.
    public AudioSource rewardSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Reset the current score each time the game is restarted.
        currentScore = "0";
        score = 0;
    }
    
    // Create definition for high score found within the program upon update.
    private float highScore = 0F;

    // Update is called once per frame
    void Update()
    {
        // Load the required variables for the textMesh into memory.
        currentScore = scoreCounter.text;
        score = float.Parse(currentScore);

        // Update the text.
        score += 0.1F;

        // If the current score is greater then the last high score create a award.
        if (score >= highScore + 100F)
        {
            // Add the current high score to the last high score.
            highScore += 100F;

            // Play the reward sound.
            rewardSound.Play();

            // Increase the score by a desired amount.
            score += 10F;
        }

        // Store the updated text back into the textMesh data section.
        currentScore = score.ToString();
        scoreCounter.text = currentScore;
    }
}
