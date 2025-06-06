using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{

    //movement cooldown after reset or first spawn
    private float movementCooldown = 0f;
    private Vector2 movement;
    public float speed = 30;
    private float currentSpeed = 0;
    public TextMeshPro text;

    private Rigidbody rb;
    public GameObject GM;
    public GameObject envSpawner;


    public bool isSlowed = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
        ResetCooldown();
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
            if (movement.x < 0 && transform.position.x > -14)
                transform.Translate(movement.x, 0, 0);
        }
        //cooldown for movement
        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
        }
        else
        {
            movementCooldown = 0;
        }
    }

    public void OnMovement(InputValue value)
    {
        //check if cooldown is active
        if (movementCooldown <= 0)
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

                GetComponent<AudioSource>().pitch = 0.5f;
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
                GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<Movement>().speed = 0;
                envSpawner.GetComponent<SideSpawner>().StopSpawner();

            }
            else
            {
                isSlowed = false;
                ResetSpeed();
                GM.GetComponent<ChaseManager>().DecreceChaseProgress(0.5f);

                GetComponent<AudioSource>().pitch = 0.75f;
                GM.GetComponent<ObstacleSpawner>().StartSpawner();

                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    obstacle.GetComponent<Movement>().speed = 5;

                    if (obstacle.GetComponent<FollowTarget>() != null)
                    {
                        obstacle.GetComponent<FollowTarget>().ResetFollowSpeed();
                    }
                }
                GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<Movement>().speed = 5f;
                envSpawner.GetComponent<SideSpawner>().StartSpawner();
            }
        }
        else if (GM.GetComponent<GameStateManager>().GetGameState() == "Paused" || GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().SetUpgradeCounts();
            GM.GetComponent<GameStateManager>().ToggleShopScreen();
        }
        Debug.Log("A Button Pressed");

    }

    public void OnB()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Paused")
        {
            ResetCooldown();
            GM.GetComponent<GameStateManager>().StartGame();
        }
        else if (GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().BuyChaseBuffer();
        }
        else if (GM.GetComponent<GameStateManager>().GetGameState() == "Running")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
        Debug.Log("B Button Pressed");
    }

    public void OnX()
    {
        if (GM.GetComponent<GameStateManager>().GetGameState() == "Shop")
        {
            GM.GetComponent<ShopManager>().BuyMultiplier();
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

    public void ResetCooldown()
    {
        movementCooldown = 0.5f;
    }
}
