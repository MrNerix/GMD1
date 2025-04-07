using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 movement;
    private float speed = 35;
    private bool isGrounded = false;
    public TextMeshPro text;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {   
        transform.Translate(movement.x, 0, 0);
    }
    
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>() * Time.deltaTime * speed;

        if(value.Get<Vector2>().y > 0 && isGrounded){
            rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
    
    public void OnA()
    {
        Debug.Log("A");
    }
    
    public void OnB()
    {
        text.text = "B";
    }
    
    public void OnX()
    {
        text.text = "X";
    }
    
    public void OnY()
    {
        text.text = "Y";
    }
    
    public void OnLeftTrigger()
    {
        text.text = "L Trigger";
    }
    
    public void OnRightTrigger()
    {
        text.text = "R Trigger";
    }
    
    public void OnStart()
    {
        text.text = "Start";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
