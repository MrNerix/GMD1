using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class GameStateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScr;
    private float playerSpeed;

    public string gameState;

    public GameObject envSpawner;

    public GameObject shopScreen;

    public GameObject monster;


    public GameObject evnWarmup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerSpeed = player.GetComponent<Player>().speed;
        gameState = "Running"; // Initial game state
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopGame()
    {
        gameState = "Paused";
        gameObject.GetComponent<ObstacleSpawner>().StopSpawner();
        player.GetComponent<Player>().SetSpeed(0);
        gameOverScr.SetActive(true);

        GetComponent<AudioSource>().volume = 0f;
        monster.GetComponent<AudioSource>().volume = 0f;

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Movement>().speed = 0;
        }
        GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<Movement>().speed = 0;
        // Stop the environment spawner
        envSpawner.GetComponent<SideSpawner>().StopSpawner();

        player.GetComponent<Player>().GetComponent<AudioSource>().volume = 0f;
        player.GetComponent<Player>().isSlowed = false;
        GetComponent<ChaseManager>().DecreceChaseProgress(0.5f);

        // Setting score speed to 0
        GetComponent<ScoreManager>().speed = 0;

        GetComponent<CurrencyManager>().AddCurrencyFromScore(GetComponent<ScoreManager>().GetScore());
        
    }

    public void ToggleShopScreen()
    {
        
        if (!shopScreen.activeSelf)
        {
            gameState = "Shop";
            shopScreen.SetActive(true);
        }
        else
        {
            gameState = "Paused";
            shopScreen.SetActive(false);
        }
    }



    public void StartGame()
    {

        player.GetComponent<AudioSource>().volume = 0.2f;
        player.GetComponent<AudioSource>().pitch = 0.75f;
        

        GetComponent<AudioSource>().volume = 0.2f;
        gameState = "Running";
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        player.GetComponent<Health>().FullHealth();

        gameObject.GetComponent<ObstacleSpawner>().StartSpawner();
        player.GetComponent<Player>().ResetSpeed();
        gameOverScr.SetActive(false);


        GameObject.FindGameObjectsWithTag("Ground")[0].GetComponent<Movement>().speed = 5f;

        envSpawner.GetComponent<SideSpawner>().StartSpawner();

        GetComponent<ScoreManager>().speed = playerSpeed;
        GetComponent<ScoreManager>().runTime = 0f;
        player.GetComponent<Health>().HealthText();

        Instantiate(evnWarmup, new Vector3(0, 0f, 0f), Quaternion.identity);
    }
    public string GetGameState()
    {
        return gameState;
    }
}

