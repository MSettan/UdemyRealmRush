using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private GameObject shootFX;

    private int hitPoints = 10;

    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void OnCollisionEnter(Collision other)
    {
        Collider shootCollider = shootFX.GetComponent<Collider>();
        
            print("Yep");
        
    }
}
