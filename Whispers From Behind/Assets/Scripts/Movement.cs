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

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1 * Time.deltaTime * speed);

        
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.z <= -30)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 30);
            }
        }
    }
}
