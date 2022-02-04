
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHitPoints = 5;
    public int currentHitPoints;

   
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    void Hit()
    {
        Debug.Log("hit");
        currentHitPoints --;
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
