
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints;

   
    void OnEnable()
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
            gameObject.SetActive(false);
        }
    }
}
