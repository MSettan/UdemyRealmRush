using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] int healthDecrease = 1;
    
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
       print("you was hitting");
    }
}
