using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters of each tower
    [SerializeField] private Transform objectToPan;
    [SerializeField] private float shootDistance = 20;
    [SerializeField] private GameObject shootFX;
    
    //state of each tower
    private Transform _targetEnemy;
    private ParticleSystem.EmissionModule _shootEmission;

    private void Start()
    {
        _shootEmission = shootFX.GetComponent<ParticleSystem>().emission;//on, off firing
    }

    void Update()
    {
        SetTargetEnemy();
        
        if (_targetEnemy)
        {
            objectToPan.LookAt(_targetEnemy);
            FireAtEnemy();
        }
        else
        {
            _shootEmission.enabled = false;
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        if(sceneEnemies.Length == 0 ){return;}

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (var testEnemy in sceneEnemies)
        {
            closestEnemy = getClosest(closestEnemy, testEnemy.transform);
        }

        _targetEnemy = closestEnemy;
    }

    private Transform getClosest(Transform closestEnemy, Transform testEnemy)
    {
        float distanceTowerToEnemy = Vector3.Distance(transform.position, testEnemy.position);
        float distanceTowerToClosest = Vector3.Distance(transform.position, closestEnemy.position);
        
        if (distanceTowerToClosest > distanceTowerToEnemy)
        {
            return testEnemy;
        }

        return closestEnemy;
    }

    private void FireAtEnemy()
    {
        float checkDistance = Vector3.Distance(objectToPan.position,_targetEnemy.position);
        
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
