using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 5;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;
    
    private void OnParticleCollision(GameObject other)
    {
        KillEnemy(); 
        //print("hitPoints = " + _hitPoints);
    }

    private void KillEnemy()
    {
        hitParticlePrefab.Play();
        if (hitPoints != 0)
        {
            hitPoints--;
        }
        else
        {
            var particleSystem = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            particleSystem.Play();
            
            float destroyDelay = particleSystem.main.duration;
            Destroy(particleSystem.gameObject, destroyDelay);
            
            Destroy(gameObject);
        }
    }
    
}
