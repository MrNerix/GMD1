using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class GameStateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScr;
    private float playerSpeed;

    public string gameState;

    public GameObject shopScreen;
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


        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Movement>().speed = 0;
        }

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

        GetComponent<ScoreManager>().speed = playerSpeed;
        GetComponent<ScoreManager>().runTime = 0f;
        player.GetComponent<Health>().HealthText();
    }
    public string GetGameState()
    {
        return gameState;
    }
}

