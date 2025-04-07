using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHeath = 100;
    [SerializeField]
    private int health;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = maxHeath;
    }

    public void DamageHealth(int damage){
        health = health - damage;
        Debug.Log(health);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
