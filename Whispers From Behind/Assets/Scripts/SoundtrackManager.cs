using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    // Dont destroy this object when loading a new scene
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
