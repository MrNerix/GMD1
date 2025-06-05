using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private GameObject enemy;

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
        Instantiate(obstacle, new Vector3(Random.Range(-14, 14), 0.5f, 20f), Quaternion.identity);
    }

    void SpawnEnemy(){
        Instantiate(enemy, new Vector3(Random.Range(-14, 14), 0.5f, 20f), Quaternion.identity);
    }
    public void StopSpawner()
    {
        CancelInvoke();
    }
    public void StartSpawner()
    {
        InvokeRepeating("SpawnObstacle", 1f, 0.5f);
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }
}
