using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    private Vector2 movement;
    public float speed = 60;
    private float currentSpeed = 0;
    public TextMeshPro text;

    private Rigidbody rb;
    public GameObject GM;


    public bool isSlowed = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
    void FixedUpdate()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Running")
        {
            if (movement.x > 0 && transform.position.x < 14)
                transform.Translate(movement.x, 0, 0);
            if(movement.x < 0 &&  transform.position.x > -14)
                transform.Translate(movement.x, 0, 0);
        }
        
    }
    
    public void OnMovement(InputValue value)
    {
            movement = value.Get<Vector2>() * Time.deltaTime * currentSpeed;

    }

    public void OnA()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Running")
        {
            if (!isSlowed)
            {
                isSlowed = true;
                SetSpeed(10);
                GM.GetComponent<ChaseManager>().IncreceChaseProgress(0.5f);


                GM.GetComponent<ObstacleSpawner>().StopSpawner();

                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    obstacle.GetComponent<Movement>().speed = 0;
                    if (obstacle.GetComponent<FollowTarget>() != null)
                    {
                        obstacle.GetComponent<FollowTarget>().StopFollow();
                    }
                }

            }
            else
            {
                isSlowed = false;
                ResetSpeed();
                GM.GetComponent<ChaseManager>().DecreceChaseProgress(0.5f);

                GM.GetComponent<ObstacleSpawner>().StartSpawner();

                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    obstacle.GetComponent<Movement>().speed = 10;

                    if (obstacle.GetComponent<FollowTarget>() != null)
                    {
                        obstacle.GetComponent<FollowTarget>().ResetFollowSpeed();
                    }
                }
            }
        }
        else if (GM.GetComponent<GameStateManager>().GetGameState() == "Paused" || GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<GameStateManager>().ToggleShopScreen();
        }
        Debug.Log("A Button Pressed");

    }

    public void OnB()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Paused")
        {
            GM.GetComponent<GameStateManager>().StartGame();
        }
        else if (GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().BuyMultiplier();
        }
        Debug.Log("B Button Pressed");
    }

    public void OnX()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().BuyChaseBuffer();
        }
        Debug.Log("X Button Pressed");
    }
    
    public void OnY()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().BuyHealthUpgrade();
        }
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

}
