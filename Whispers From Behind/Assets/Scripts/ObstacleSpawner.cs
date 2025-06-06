using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject obstacle;
    //[SerializeField]

    // Array of GameObjects to spawn as obstacles
    public GameObject[] obstacles;

    public GameObject enemy;

    // Array of GameObjects to spawn as trees
    public GameObject[] trees;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartSpawner();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }


    void SpawnObstacle(){
        
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(Random.Range(-14, 14), 0f, 20f), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }

    void SpawnEnemy(){

        Instantiate(enemy, new Vector3(Random.Range(-14, 14), 0f, 20f), Quaternion.Euler(0, 180, 0));
    }

    void SpawnTree()
    {
        Instantiate(trees[Random.Range(0, trees.Length)], new Vector3(Random.Range(-14, 14), 0f, 20f), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    public void StopSpawner()
    {
        CancelInvoke();
    }
    public void StartSpawner()
    {
        InvokeRepeating("SpawnObstacle", 0f, 0.5f);
        InvokeRepeating("SpawnEnemy", 0f, 5f);
        InvokeRepeating("SpawnTree", 0f, 1f);
    }
}
