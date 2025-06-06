using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target; // The target to follow
    private GameObject gameManager; // Reference to the game manager

    private float currentFollowSpeed = 2f; // Speed at which this object follows the target
    private float maxFollowSpeed = 1f; // Default follow speed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object by tag 
        if (target == null)
        {
            Debug.LogError("Player object not found! Make sure it has the tag 'Player'.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // set x possition to target's x position
        if (target != null)
        {

            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y; // Keep the y position constant
            targetPosition.z = transform.position.z; // Keep the z position constant

            // Move towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, currentFollowSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target is null, cannot follow.");
        }

    }

    // method to set the follow speed
    public void StopFollow()
    {
        currentFollowSpeed = 0;
    }

    public void ResetFollowSpeed()
    {
        currentFollowSpeed = maxFollowSpeed; // Reset to the default follow speed
    }
}
