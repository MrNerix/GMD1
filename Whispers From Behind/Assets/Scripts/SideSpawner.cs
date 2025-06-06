using UnityEngine;

public class SideSpawner : MonoBehaviour
{

    // Array of GameObjects to spawn
    public GameObject[] objectsToSpawn;

    // Array of GameObjects to spawn props on the road
    public GameObject[] propsToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartSpawner();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
        Instantiate(objectsToSpawn[Random.Range(0, 2)], new Vector3(Random.Range(-20, -15), 0f, 30f), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(objectsToSpawn[Random.Range(0, 2)], new Vector3(Random.Range(15, 20), 0f, 30f), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    void SpawnBushes()
    {
        Instantiate(objectsToSpawn[Random.Range(2, objectsToSpawn.Length)], new Vector3(Random.Range(-20, -15), 0f, 30f), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(objectsToSpawn[Random.Range(2, objectsToSpawn.Length)], new Vector3(Random.Range(15, 20), 0f, 30f), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    void SpawnProp()
    {
        Instantiate(propsToSpawn[Random.Range(0, propsToSpawn.Length)], new Vector3(Random.Range(-15, 15), 0f, 25f), Quaternion.Euler(0, Random.Range(0, 360), 0));
        Instantiate(propsToSpawn[Random.Range(0, propsToSpawn.Length)], new Vector3(Random.Range(-15, 15), 0f, 25f), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
    public void StartSpawner()
    {
        InvokeRepeating("SpawnObject", 0f, 0.4f);
        InvokeRepeating("SpawnObject", 0.1f, 0.4f);
        InvokeRepeating("SpawnBushes", 0f, 0.2f);
        InvokeRepeating("SpawnProp", 0f, 0.05f);
    }
    public void StopSpawner()
    {
        CancelInvoke();
    }
}
