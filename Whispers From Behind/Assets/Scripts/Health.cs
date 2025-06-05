using System;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHeath = 2;
    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject GM;

    public TMP_Text healthText; // Reference to the UI text component to display health


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = maxHeath;
    }

    public void DamageHealth(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            GM.GetComponent<GameStateManager>().StopGame();
        }
        HealthText(); // Update the UI text to reflect the new health amount
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void FullHealth()
    {
        health = maxHeath;
    }
    public void HealthText()
    {
        healthText.text = health.ToString(); // Update the UI text with the current health amount
    }

    public void IncreceMaxHealth(int amount)
    {
        maxHeath += amount;
        health = maxHeath; // Reset current health to new max health
        HealthText(); // Update the UI text to reflect the new max health
    }
    public int GetMaxHealth()
    {
        return maxHeath;
    }
}
