using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private int maxHeath = 100;
    [SerializeField]
    private int health;
    
    [SerializeField]
    private GameObject GM;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = maxHeath;
    }

    public void DamageHealth(int damage){
        health = health - damage;
        if(health <= 0){
            GM.GetComponent<GameStateManager>().StopGame();
        }
        Debug.Log(health);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void FullHealth(){
        health = maxHeath;
    }

}
