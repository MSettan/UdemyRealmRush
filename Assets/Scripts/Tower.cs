using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private float shootDistance = 20;
    [SerializeField] private GameObject shootFX;

    private ParticleSystem.EmissionModule _shootEmission;

    private void Start()
    {
        _shootEmission = shootFX.GetComponent<ParticleSystem>().emission;//on, off firing
    }

    void Update()
    {
        objectToPan.LookAt(targetEnemy);

        FireAtEnemy();
    }

    private void FireAtEnemy()
    {
        float checkDistance = Vector3.Distance(objectToPan.position,targetEnemy.position);
        
        if (checkDistance <= shootDistance)
        {
            _shootEmission.enabled = true;
        }
        else
        {
            _shootEmission.enabled = false;
        }
    }
    
}
