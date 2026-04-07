using System.Threading.Tasks;
using UnityEngine;

public class currentScript : MonoBehaviour
{
    // Gather require infomation in unity interface.
    public string currentCharacter = "mainCharacter";
    public string characterName = "Docker";
    public int displaymentAmount = 0;
    public float gravityMovement = 0.1F;
    public int velocityMS = 0;
    public float displaymentDirection = -1;

    // Create the private infomation.
    private GameObject mainCharacterObject;
    private float curYIndex = 0;
    private bool updateCharacterPos = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set init value for y.
        curYIndex = transform.position.y;

        // Make sure to gather the location of the game object.
        mainCharacterObject = GameObject.Find(characterName);
    }

    // On the collision make sure to change the position of the object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Create the position of the character based on the script;
        if (collision.CompareTag(currentCharacter))
        {
            // Update position.
            updateCharacterPos = true;

            // Update position for video quickly.
            Vector2 characterPos = new(mainCharacterObject.transform.position.x + displaymentDirection * gravityMovement * 4, mainCharacterObject.transform.position.y);
            mainCharacterObject.transform.position = characterPos;

            // Wait the required amount of time.
            Task.Delay(velocityMS);

            // Do not update character position.
            updateCharacterPos = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Upon update for index.
        curYIndex += gravityMovement;

        // Update the current value for x based on the current load.
        float xDisplayed = displaymentAmount * Mathf.Sin(curYIndex);

        // If the value for the pos is true update it.
        if (updateCharacterPos == true)
        {
            Vector2 characterPos = new(mainCharacterObject.transform.position.x + displaymentDirection * gravityMovement, mainCharacterObject.transform.position.y);
            mainCharacterObject.transform.position = characterPos;
        }

        // Update the current position of the object.
        Vector2 posVector = new((transform.position.x + xDisplayed), curYIndex);
        transform.position = posVector;
    }
}
