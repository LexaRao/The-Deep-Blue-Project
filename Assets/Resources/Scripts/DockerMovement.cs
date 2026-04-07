// using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DockerMovement : MonoBehaviour
{
    // Create the buttons in public so they can be accessed by unity.
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;
    public Button okButton;

    // Create a setting for the speed of the character;
    public Vector2 charSpeed = new(0, 0);

    // Create a setting for the character current location.
    private Vector2 charLocation = new(0, 0);

    // Create varibles for when the buttons are being pressed that will allow the code to update as intended.
    bool moveUp = false;
    bool moveDown = false;
    bool moveLeft = false;
    bool moveRight = false;

    // Edge of screens.
    public float EdgeOfScreen = 11F;

    // Over or under the screen.
    public float OverUnderScreen = 10F;

    // The amount of lives left counter.
    public TextMeshProUGUI livesLeft;

    // Create code for the consequence sound within the game.
    public AudioSource consequenceSound;

    // Create the code for the onClick sound within the game.
    public AudioSource onClickSound;

    // Create the losing scene which can be edited by unity.
    public string losingScene = "Game_Over";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize all the buttons and make sure to set the to the current position.
        // Initialize up button.
        Button upButtonWrapper = upButton.GetComponent<Button>();

        // When the down button is pressed.
        Button downButtonWrapper = downButton.GetComponent<Button>();

        // When the left button is pressed.
        Button leftButtonWrapper = leftButton.GetComponent<Button>();

        // When the right button is pressed.
        Button rightButtonWrapper = rightButton.GetComponent<Button>();

        // When the button is pressed set the function as required.
        // For the up button.
        upButtonWrapper.onClick.AddListener(upPressed);

        // For the down button.
        downButtonWrapper.onClick.AddListener(downPressed);

        // For the left button.
        leftButtonWrapper.onClick.AddListener(leftPressed);

        // For the right button.
        rightButtonWrapper.onClick.AddListener(rightPressed);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the character current location.
        charLocation = transform.position;

        // Change the direction of movement based on the current direction.
        if (moveUp == true) // Upward movement.
        {
            charLocation.y += charSpeed.y;
            moveUp = false;
        } else if (moveDown == true) // Downward movement.
        {
            charLocation.y -= charSpeed.y;
            moveDown = false;
        } else if (moveLeft == true) { // Left movement.
            charLocation.x -= charSpeed.x;
            moveLeft = false;
        } else if (moveRight == true) // Right movement.
        {
            charLocation.x += charSpeed.x;
            moveRight = false;
        }

        // Set the character location based on the updated position.
        transform.position = charLocation;

        // When the given location is out of bounds make sure to reset the position have the character lose a life.
        if (transform.position.x >= EdgeOfScreen || transform.position.x <= EdgeOfScreen * -1) // Two far to the left or right.
        {
            // Call the function for handling the character being out of bounds.
            outOfBounds();
        } else if (transform.position.y >= OverUnderScreen || transform.position.y <= OverUnderScreen * -1) // Over-Or-Under Screen.
        {
            // Call the function for handling the character being out of bounds.
            outOfBounds();
        }
    }

    // Create function for when the up button is pressed.
    public void upPressed()
    {
        // When pressed create noise for the button.
        onClickSound.Play();

        // When the button is pressed set the value to true.
        moveUp = true;
    }

    // Create a function for when the down button is pressed.
    public void downPressed()
    {
        // When clicked create noise for the button.
        onClickSound.Play();

        // When the button is pressed set the value to true.
        moveDown = true;   
    }

    // Create a function for when the left button is pressed.
    public void leftPressed()
    {
        // When clicked create a noise for the button.
        onClickSound.Play();

        // When the button is pressed set the value to true.
        moveLeft = true;
    }

    // Create a function for when the right button is pressed.
    public void rightPressed()
    {
        // When clicked create a noise for the button.
        onClickSound.Play();

        // When the button is pressed set the value to true.
        moveRight = true;
    }

    // Create a function for when the ok button is being pressed.
    public void okPressed()
    {
        // When clicked create a noise for the button.
        onClickSound.Play();
    }

    // Create a function for when the game character is out of bounds.
    public void outOfBounds()
    {
        // Determine how many lives the character has left and decrease the life count then end game if zero.
        // Gather the amount of lives the character has left.
        float amountLivesLeft = float.Parse(livesLeft.text);

        // Decrease the amount of lives left.
        amountLivesLeft -= 1F;

        // Play the consequence sound.
        consequenceSound.Play();

        // If the amount of lives left is zero end the game.
        if (amountLivesLeft <= 0F)
        {
            SceneManager.LoadScene(losingScene);
        } else // Otherwise reset the character cordinates for x to 0 and y to 0.
        {
            Vector2 currentPosition = transform.position;
            currentPosition.x = 0;
            currentPosition.y = 0;
            transform.position = currentPosition;
        }

        // Set the amount of lives left in game.
        livesLeft.text = amountLivesLeft.ToString();
    }

}
