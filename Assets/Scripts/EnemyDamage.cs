using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int hitPoints = 5;
    
    private void OnParticleCollision(GameObject other)
    {
        KillEnemy(); 
        //print("hitPoints = " + _hitPoints);
    }

    private void KillEnemy()
    {
        if (hitPoints != 0)
        {
            hitPoints--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
