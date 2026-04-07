using UnityEngine;

public class DockerTenticals : MonoBehaviour
{
    // Create the require public variables.
    // Create a variable for offset.
    public float offset = 0F;

    // Create the variable for magnutude.
    public float magnutude = 2F;

    // Create a variable for the fixed length.
    public float fixedLength = 0.5F;

    // Create the integer for the current count.
    private float currentCount = 0F;

    // Create a variable for storing the local scale.
    private Vector2 localScale = new(0, 0);

    // Create a selector for a vertical change.
    public bool isFlipper = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the scale dynamicaly based on what on the current frame.
        // Get local scale.
        localScale = transform.localScale;

        if (isFlipper == false) { // If the item is not a flipper make sure to update the tentical horizontally.
            // Update the local scale.
            localScale.y = fixedLength + magnutude * ((currentCount + offset) % (2F * 3.14F));
        } else // Otherwise update it vertically.
        {
            // Update the local scale vertically.
            localScale.x = fixedLength + magnutude * ((currentCount + offset) % (2F * 3.14F));
        }

        // Update the current count.
        currentCount += 0.1F;

        // Set the local scale;
        transform.localScale = localScale;
    }
}
