using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tokenScript : MonoBehaviour
{
    // Current score and the name of docker and require assests.
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI livesLeft;
    public string nameOfCharacter = "Docker";
    public Button okButton;
    public AudioSource bigRewardNoise;
    
    // Get the growth each movement.
    public float gravityMovement = 0.1F;

    // Create the required varables.
    private GameObject mainCharacter;
    private float curYIndex = 0;
    private bool descriptionRequested = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the name of the main character.
        mainCharacter = GameObject.Find(nameOfCharacter);

        // Get the current index of y.
        curYIndex = transform.position.y;

        // Create the connection for the ok button.
        Button okButtonWrapper = okButton.GetComponent<Button>();
        okButtonWrapper.onClick.AddListener(onClick);
    }

    // If a collision occurs make sure to update the current position.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Define required definitions.
        string tmp = "";

        // If the description is not present then you can do the task required.
        if (descriptionRequested == false) {
            // Create the required consequence when the collision happens with docker.
            if (collision.CompareTag(nameOfCharacter))
            {
                // Update the current points.
                currentScore.text = (float.Parse(currentScore.text) + 200).ToString();
                livesLeft.text = (float.Parse(livesLeft.text) + 1).ToString();

                // Play the reward music.
                bigRewardNoise.Play();
            }
        } else // Make sure to do the description if it ok is pressed.
        {
            // Save value.
            tmp = livesLeft.text;

            // Change the value of the description.
            livesLeft.text += "\n\nCoin is reward.";

            // Wait ten seconds for users to read message.
            Task.Delay(10000);

            // Swap value back for the original value.
            livesLeft.text = tmp;
        }
    }

    // Create the on click function for the ok button.
    void onClick()
    {
        // Create a wait period whre the description update is ok.
        descriptionRequested = true;

        // Create wait period for two seconds.
        Task.Delay(2000);

        // Create the function for not waiting anymore.
        descriptionRequested = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Onload the current y index.
        curYIndex = transform.position.y;

        // Update the y index.
        curYIndex += gravityMovement;

        // Create variable with this data init.
        Vector2 curIndex = new(transform.position.x,curYIndex);

        // Load the current y index.
        transform.position = curIndex;
    }
}
