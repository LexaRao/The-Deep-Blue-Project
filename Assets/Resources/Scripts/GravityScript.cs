using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// The current script allows for the position of a active object to be changed based on the field of gravity.
// The strength of the field on a given object can be changed based on the objects on the screen.

public class GravityScript : MonoBehaviour
{
    // Create a variable that displays the amount of lives you currently have left.
    public TextMeshProUGUI livesLeftCounter;
    float livesLeft = 3F;
    string livesLeftHolder = "";

    // Create a varable for the rate of falling due to gravity.
    public float fallRate = 0.1F;

    // Create a vector for storing the changing fall rate.
    private Vector2 currentPos = new(0, 0);

    // Create the audio source for the you lost a life sound.
    public AudioSource consequenceSound;

    // Create the winning and losing scene which can be edited by unity.
    public string gameOverScene = "Game_Over";
    public string winningScene = "You_Win";

    // Create a variable for if the game object is a character.
    public bool isCharacter = false;

    // Make sure to the are for dockers character.
    public string targetObject = "Docker";
    GameObject dockerObject;

    // Determine if the gravity is in the form of a gravity well.
    public bool isGravityWell = false;
    public int gravityRadius = 0;
    public float gravitySpeed = 0F;

    // Create the built-in required function for the program.
    private float signCur = 1F;
    private float curXIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure to set the lives left counter.
        livesLeftCounter.text = livesLeft.ToString();

        // Make sure to gather the  game character data.
        dockerObject = GameObject.Find(targetObject);
    }

    // Detect if a colision has happened.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Determine if the collision was with docker.
        if (collision.CompareTag("mainCharacter")) {
            // Update the current amount of lives.
            // Get the current amount of lives left.
            livesLeftHolder = livesLeftCounter.text;
            livesLeft = float.Parse(livesLeftHolder);

            // Update the count by decreasing it given the collision.
            livesLeft -= 1F;

            // Save the lives left back in the current lives count.
            livesLeftHolder = livesLeft.ToString();
            livesLeftCounter.text = livesLeftHolder;

            // Play an effect to let the users know they have lost a life.
            consequenceSound.Play();

            // If the current amount of lives left is zero make sure to end the game.
            if (livesLeft == 0F)
            {
                SceneManager.LoadScene(gameOverScene);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the object.
        currentPos = transform.position;

        // Set the fall rate for the project.
        currentPos.y += fallRate;


        // Make sure gravity wells only happen when the setting is true or when the character setting is true.
        if (isGravityWell == true || isCharacter == true) {
            // Make sure to move back and forth on the plane according to the theory of a gravity well.
            if (curXIndex >= gravityRadius * -1F && curXIndex <= gravityRadius)
            {
                curXIndex = curXIndex + signCur * gravitySpeed;
            } else // Otherwise, make sure to change the sign so the x value is in range.
            {
                signCur = signCur * -1F;
                curXIndex = curXIndex + signCur * gravitySpeed;
            }

            // Change the value for the current transform based on the x value.
            currentPos.x = curXIndex;


            // Only do this when the character is not a gravity well.
            if (isCharacter == false) {
                // Determine the value for y based on this value for x on top of the present x value.
                currentPos.y += curXIndex - (curXIndex + (signCur * -1));
            }    
        }

        // If the current item is a character make sure to change the x value so it follows docker.
        if (isCharacter == true)
        {
            currentPos.x += dockerObject.transform.position.x;
        }

        // When you win the game make sure to call the function for winning the game.
        if (currentPos.y >= 0)
        {
            // Call the function that tells the users you are winning the game.
            youWin();
        }

        // Set the new position based on what has happened in the gravity script.
        transform.position = currentPos;
    }

    // Create a function for when you win the game.
    public void youWin()
    {
        // Identity the name of the object and if it is the correct object make sure to go to the winning scene.
        if (gameObject.CompareTag("Ground")) {
            // When you win make sure to jump to the you in page of the game.
            SceneManager.LoadScene(winningScene);
        }
    }
}