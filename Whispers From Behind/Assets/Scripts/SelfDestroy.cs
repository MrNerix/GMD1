using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // This script is used to destroy the GameObject after a certain time
    public float destroyTime = 10f; // Time in seconds before the GameObject is destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start the coroutine to destroy the GameObject after the specified time
        StartCoroutine(DestroyAfterTime(destroyTime));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private System.Collections.IEnumerator DestroyAfterTime(float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);
        // Destroy the GameObject
        Destroy(gameObject);
    }
}
