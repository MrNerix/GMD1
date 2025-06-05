using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, -1 * Time.deltaTime * speed);
    }
}
