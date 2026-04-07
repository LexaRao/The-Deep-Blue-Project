using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onClick : MonoBehaviour
{
    // Create a public button for the given framework.
    public Button linkedButton;

    // Create a scene you would like the project to link to.
    public string targetScene;

    // Create sound effect for the clicks found in the game.
    public AudioSource onClickSound;

    // Create the interface for recording the top level.
    public bool levelPassed = false;
    public int currentLevel = 0;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create the data from the blueprint for the given button and attach to the current framework.
        Button myButton = linkedButton.GetComponent<Button>();
        myButton.onClick.AddListener(OnClick);
    }

    // When the button is clicked load the current scene for the program.
    void OnClick() {
        // Play the on click sound.
        onClickSound.Play();

        // If the current level has been added make sure to change the lcoal data to suppor this change.
        if (levelPassed == true)
        {
            // Alter the local data to support this change.
            if (PlayerPrefs.HasKey("Player_Top_Level"))
            {
                // Record the top level based on the game progress.
                PlayerPrefs.SetInt("Player_Top_Level", currentLevel + 1);
            } else
            {
                // Record the players key based on the current key for it.
                PlayerPrefs.SetInt("Player_Top_Level", currentLevel + 1);
            }
        }

        // Load the current scene.
        SceneManager.LoadScene(targetScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
