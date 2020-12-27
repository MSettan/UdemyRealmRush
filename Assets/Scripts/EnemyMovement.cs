using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementPeriod = .5f;
    [SerializeField] private ParticleSystem goalParticle;
    
    private void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }
    
    private void SelfDestruct()
    {
        var particleSystem = Instantiate(goalParticle, transform.position, Quaternion.identity);
            particleSystem.Play();
            
            float destroyDelay = particleSystem.main.duration;
            Destroy(particleSystem.gameObject, destroyDelay);
            
            Destroy(gameObject);
        
    }
}
