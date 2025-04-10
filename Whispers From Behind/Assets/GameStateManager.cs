using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class GameStateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopGame(){
        gameObject.GetComponent<ObstacleSpawner>().StopSpawner();
        player.GetComponent<Player>().speed = 0;
        gameOverScr.SetActive(true);

        GameObject[] obstacles =  GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in obstacles){
            obstacle.GetComponent<Movement>().speed = 0;
        }
    }
    public void StartGame(){
        GameObject[] obstacles =  GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in obstacles){
            Destroy(obstacle);
        }
        player.GetComponent<Health>().FullHealth();

        gameObject.GetComponent<ObstacleSpawner>().StartSpawner();
        player.GetComponent<Player>().speed = 60;
        gameOverScr.SetActive(false);
    }
}
