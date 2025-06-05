using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public float speed;
    public float runTime;
    [SerializeField]
    private int score;

    [SerializeField]
    private TMP_Text scoreText;

    public int multiplier = 1; // Multiplier for score calculation


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //set default values for speed
        speed = FindFirstObjectByType<Player>().GetComponent<Player>().speed;
        score = 0;
        // Initialize runTime to 0
        runTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Time since awake
        runTime += Time.deltaTime;
        // Increment the score based on speed and time
        if (speed > 0)
            UpdateScore();
        scoreText.text = score.ToString();
    }
    private void UpdateScore()
    {
        // Increment the score based on speed and time * multiplier
        score = Mathf.FloorToInt(speed * runTime * multiplier);
    }
    public int GetScore()
    {
        return score;
    }
    public void IncreaseMultiplier(int amount)
    {
        multiplier += amount;
        // Ensure multiplier does not go below 1
        if (multiplier < 1)
        {
            multiplier = 1;
        }
    }
    public int GetMultiplier()
    {
        return multiplier;
    }

}
