using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.Translate(0, 0, -1 * Time.deltaTime * speed);
        // same thhing but using global position
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1 * Time.deltaTime * speed);

        // Check if object tag is "Ground" and if so reset its position so it appears to be moving infinitely the size of the ground beigh 30 so the repeating texture is seamless
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.z <= -30)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 30);
            }
        }
    }
}
