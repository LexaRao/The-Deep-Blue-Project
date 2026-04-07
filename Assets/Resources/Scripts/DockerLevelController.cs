using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DockerLevelController : MonoBehaviour
{
    // Create the public interface for loading buttons and selecting the name of the main character.
    public Button leftButton;
    public Button rightButton;
    public Button okButton;
    // public string mainCharacter = "docker";
    public TextMeshProUGUI currentScore;
    public AudioSource onClickMusic;

    // Create the private variables.
    private int curLevel = 0;
    private int topLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create the liseners required for the buttons in the game.
        // Add ok button connector.
        Button onClickOkWrapper = okButton.GetComponent<Button>();
        onClickOkWrapper.onClick.AddListener(onClickOk);

        // Add the left click button connector.
        Button onClickLeftWrapper = leftButton.GetComponent<Button>();
        onClickLeftWrapper.onClick.AddListener(onClickLeft);

        // Add the connector for the right button.
        Button onClickRightWrapper = rightButton.GetComponent<Button>();
        onClickRightWrapper.onClick.AddListener(onClickRight);

        // Create the require definition for the current level in memory if it does not exist otherwise set it the top level.
        if (PlayerPrefs.HasKey("Player_Top_Level")) {
            topLevel = PlayerPrefs.GetInt("Player_Top_Level");
        } else
        {
            topLevel = 0;
        }
    }

    // On click ok button.
    public void onClickOk()
    {
            // Play the noise for the click.
            onClickMusic.Play();

            // If the level is in range make sure to enter it.
            if (curLevel <= topLevel) {
                // When button is clicked go to the correct scene.
                string correctLevel = "Level_" + curLevel.ToString();
                SceneManager.LoadScene(correctLevel);
            }
    }

    // On click of the left button.
    public void onClickLeft()
    {
        // Change the current level based on the click.
        if (curLevel < 9) {
            curLevel++;
        }

        // Create noise based on the click.
        onClickMusic.Play();

        // When the level counter is in range change the count otherwise tell the user otherwise.
        if (curLevel <= topLevel)
        {
            // Define the current level.
            int printedLevel = curLevel + 1;
            currentScore.text = printedLevel.ToString();
        } else
        {
            // Otherwise print the message with the error.
            int printedLevel = curLevel + 1;
            currentScore.text = printedLevel.ToString() + " has not been reached yet.";
        }
    }

    // On click of right button.
    public void onClickRight()
    {
        // Change the level based on the click.
        if (curLevel > 0)
        {
            // Subtract one from the current level.
            curLevel--;
        }

        // Play the on click noise.
        onClickMusic.Play();

        // When the current level is in range tell the users.
        if (curLevel <= topLevel)
        {
            // Print the message for the users.
            int printedLevel = curLevel + 1;
            currentScore.text = printedLevel.ToString();
        } else
        {
            // Otherwise print the level has not been reach yet.
            int printedLevel = curLevel + 1;
            currentScore.text = printedLevel.ToString() + " has not been reached yet.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
