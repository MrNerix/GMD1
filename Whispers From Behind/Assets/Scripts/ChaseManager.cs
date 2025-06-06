using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ChaseManager : MonoBehaviour
{
    public Slider chaseSlider;

    public float chaseProgress = 0f;

    public bool isSlowed = false;

    private float step; // The amount to increase chase progress each time

    public GameObject gm;
    public GameObject monster;

    public int progressSlow = 1; // The amount of progress to slow down the chase


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSlowed && chaseProgress < 1f)
        {
            chaseProgress += step * Time.deltaTime;
        }
        if (!isSlowed && chaseProgress > 0f)
        {
            chaseProgress += step * Time.deltaTime;
        }

        chaseSlider.value = chaseProgress;
        
        if(GetComponent<GameStateManager>().gameState == "Running")
        {
            GetComponent<AudioSource>().volume = 0.2f + chaseProgress / 2f;
            GetComponent<AudioSource>().pitch = 1.0f + chaseProgress / 2f;

            monster.GetComponent<AudioSource>().volume = 0.2f + chaseProgress / 2f;
            monster.GetComponent<AudioSource>().pitch = 1.0f + chaseProgress / 2f;
        }
        

        if (chaseProgress >= 1f)
        {
            isSlowed = false;
           
            monster.transform.Find("Stab").gameObject.GetComponent<AudioSource>().Play();

            
            gm.GetComponent<GameStateManager>().StopGame();
            chaseProgress = 0f;
        }
    }
    public bool IsChaseEmpty()
    {
        return chaseProgress <= 0f;
    }
    public void IncreceChaseProgress(float progress)
    {
        isSlowed = true;
        step = progress / progressSlow; // Adjust the step based on the progress and slow factor
        
    }
    public void DecreceChaseProgress(float progress)
    {
        isSlowed = false;
        step = -progress;
    }

    public void SetProgressSlow(int times)
    {
        progressSlow = times;
    }
    public int GetProgressSlow()
    {
        return progressSlow;
    }




}
