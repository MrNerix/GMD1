using System;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private int damage = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player"){
            other.gameObject.GetComponent<Health>().DamageHealth(damage);
        }
    }

}
